using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controls
{
    class Array
    {
        int[] array;
        public int Length 
        { 
            get 
            { 
                return array.Length; 
            } 
        }

        public Array(DataGridView dgrv)
        {
            array = new int[dgrv.ColumnCount];
            for(int i=0;i<Length;i++)
            {
                array[i] = Convert.ToInt32(dgrv[i, 0].Value);
            }

        }
        public int Sum()
        {
            return array.Sum();
        }
        public int Pro()
        {
            int P=1;
            foreach(int a in array)
                P*=a;
            return P;
        }
        public void Output(DataGridView dgrv)
        {
            dgrv.RowCount = Length;
            for(int i=0;i<Length;i++)
            {
                dgrv[0, i].Value = array[i];
            }
        }
    }
}
