/*
 * Third Party Code that is not to be changed.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lot.O.Invitation.Codes.Services
{
    internal class NixEntropyService : IEnumerable<byte>
    {
        private static byte[] GetBytes()
        {
            using (var reader = new BinaryReader(File.Open(Configuration.EntropySource, FileMode.Open, FileAccess.Read, FileShare.Read)))
                return reader.ReadBytes(8);
        }

        public IEnumerable<byte> Generate()
        {
            while (true)
            {
                var task = Task.Run(GetBytes);
                if (Task.WhenAny(task, Task.Delay(100)).Result == task)
                {
                    foreach (var b in task.Result)
                        yield return b;
                }
                
                yield break;
            }
        }

        public IEnumerator<byte> GetEnumerator() => Generate().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
