using System;
using System.Threading.Channels;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Threading.Tasks.Dataflow;

// https://github.com/dotnet/BenchmarkDotNet

namespace tpl
{
    [MemoryDiagnoser]
    public class Program
    {

        static void Main() => BenchmarkRunner.Run<Program>();

        /*
         
        // WriteTheanRead
        private readonly Channel<int> s_channel = Channel.CreateUnbounded<int>();

        [Benchmark]
        public async Task WriteThenRead()
        {
            var writer = s_channel.Writer;
            var reader = s_channel.Reader;

            for (int i=0; i<10_000_000; i++)
            {
                writer.TryWrite(i);
                await reader.ReadAsync();
            }
        }
        */

        private readonly Channel<int> _channel = Channel.CreateUnbounded<int>();
        private readonly BufferBlock<int> _bufferBlock = new BufferBlock<int>();

        [Benchmark]
        public async Task Channel_ReadThenWrite()
        {
            var writer = _channel.Writer;
            var reader = _channel.Reader;

            for (int i=0; i<10_000; i++)
            {
                ValueTask<int> vt = reader.ReadAsync();
                writer.TryWrite(i);
                await vt;
            }
        }

        [Benchmark]
        public async Task BufferBlock_ReadThenWrite()
        {
            for (int i=0; i<10_000; i++)
            {
                Task<int> t = _bufferBlock.ReceiveAsync();
                _bufferBlock.Post(i);
                await t;
            }
        }
       
    }
}
