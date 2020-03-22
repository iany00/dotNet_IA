using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BitArray64
{
    class BitArray64 : IEnumerable<int>
    {

        //Field
        private ulong number;

        //Property
        public ulong Number
        {
            get { return number; }
            set { number = value; }
        }

        //Constructor
        public BitArray64(ulong number)
        {
            this.Number = number;
        }

        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //TODO
    }
}
