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

        public int[] numberInBits { get; set; }

        //Constructor
        public BitArray64(ulong number)
        {
            this.Number  = number;
            numberInBits = getBits();
        }

        public IEnumerator<int> GetEnumerator()
        {
            int[] bitiArr = this.numberInBits;
            for (int i = 0; i < bitiArr.Length; i++)
            {
                yield return bitiArr[i];
            }
        }

        private int[] getBits()
        {
            ulong num = this.Number;
            int[] bitiArray = new int[64];

            // transform
            string string_64 = Convert.ToString((long)num, 2).PadLeft(64, '0');
            for (int i = 0; i < string_64.Length; i++)
            {
                bitiArray[i] = int.Parse(string_64[i].ToString());
            }

            return bitiArray;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        //Equals
        public bool Equals(BitArray64 value)
        {
            if (value == null)
            {
                return false;
            }

            return this.number == value.number;
        }

        //==
        public static bool operator ==(BitArray64 num1, BitArray64 num2)
        {
            return BitArray64.Equals(num1, num2);
        }


        //!=
        public static bool operator != (BitArray64 num1, BitArray64 num2)
        {
            return !BitArray64.Equals(num1, num2);
        }

        //GetHashCode
        public override int GetHashCode()
        {
            // returns a 32-bit  integer 
            return this.number.GetHashCode();
        }

        //[]
        public int this[int index]
        {
            get
            {
                if (GetIndex(index))
                {
                    throw new IndexOutOfRangeException("The index should be in the interval [0, 63]");
                }
                else
                {
                    int[] bitsArray = this.numberInBits;
                    return bitsArray[index];
                }
            }

            set
            {
                this.numberInBits[index] = value;
            }
        }

        private bool GetIndex(int index)
        {
            if (index < 0 || index > 63)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
