﻿/*
 * 设计变更
 * 原先记录耗时是一个全静态的对象，因为最初设计就一个主线程需要记录这个数据
 * 但后面为了分流主线程的执行任务数，开了3个任务队列
 * 这样用一个统一的消息记录器就会导致多线程写文件，会产生数据错乱的问题
 * 因此把记录器作为一个对象，绑定到具体的任务队列里
 */
using System;
using System.IO;
using System.Text;
using DogSE.Library.Thread;
using DogSE.Library.Time;

namespace DogSE.Server.Core.Task
{
    /// <summary>
    /// 网络任务执行耗时记录
    /// </summary>
    internal class NetTaskCodeRuntimeWriter
    {
        private DateTime _nextDay;
        private StreamWriter _writer;
        private string _taskName;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskName"></param>
        public NetTaskCodeRuntimeWriter(string taskName)
        {
            _taskName = taskName;
            Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            var now = DateTime.Now;

            OpenFile(now);
            _nextDay = now.Date.AddDays(1);
        }

        /// <summary>
        /// 按照某个时间打开一个新的时间文件
        /// </summary>
        /// <param name="now"></param>
        private void OpenFile(DateTime now)
        {
            var fileName = string.Format(@"data\{0}\{2} NetTaskTime {1}.csv", now.ToString("yyyy-MM"),
                now.ToString("yyyy-MM-dd"), _taskName);

            if (_writer != null)
                _writer.Close();

            if (!File.Exists(fileName)) //  文件不存在则新建一个文件
            {
                new FileInfo(fileName).Directory.Create(); //  创建日志文件目录

                //  纯数字和英文的数据记录，因此开ascii的编码写入
                //  开一个2M的缓冲区，应该够日志数据的收集了。
                _writer = new StreamWriter(fileName, true, Encoding.UTF8, 1024*1024*2);
                _writer.WriteLine("TimeTick,Code,PlayerId,RunTime,WaitTime,IsException");
                //  不用自动刷新，我们有一个定时器每隔1s进行一次刷新，正常些日志时，数据会先些在写入流的缓冲区里的
                _writer.AutoFlush = false;
            }
            else
            {
                _writer = new StreamWriter(fileName, true, Encoding.UTF8, 1024*1024*2); //  开一个2M的缓冲区，应该够日志数据的收集了。
                _writer.AutoFlush = false;
            }
        }

        /// <summary>
        /// 记录数据
        /// </summary>
        /// <param name="code"></param>
        /// <param name="playerId">网络接口id（玩家id）</param>
        /// <param name="runTime"></param>
        /// <param name="waitTime"></param>
        /// <param name="isException">是否抛出异常</param>
        public void Write(ushort code, long playerId, long runTime, long waitTime, bool isException)
        {
            try
            {
                var now = OneServer.NowTime;

                var tick = now.Ticks;
                //ThreadQueue.AppendIO(() =>
                //{
                    if (now > _nextDay)
                    {
                        //  如果过了一天，则新建一个文件
                        OpenFile(now);
                        _nextDay = now.Date.AddDays(1);
                    }

                    _writer.Write(tick);
                    _writer.Write(',');
                    _writer.Write(code);
                    _writer.Write(',');
                    _writer.Write(playerId);
                    _writer.Write(',');
                    _writer.Write(runTime);
                    _writer.Write(',');
                    _writer.Write(waitTime);
                    _writer.Write(',');
                    _writer.Write(isException ? 1 : 0);
                    _writer.Write("\r\n");
                //});
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// 刷新日志文件
        /// </summary>
        public void Flush()
        {
            try
            {
                if (_writer != null)
                    _writer.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        /// <summary>
        /// 关闭文件
        /// </summary>
        public void Close()
        {
            try
            {
                if (_writer != null)
                {
                    _writer.Flush();
                    _writer.Close();
                    _writer = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
