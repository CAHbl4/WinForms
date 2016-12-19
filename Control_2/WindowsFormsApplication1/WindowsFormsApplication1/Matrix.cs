using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Matrix
    {
        int[,] matrix;

        public Matrix()
        {

        }
        public Matrix(int[,] x)
        {
            matrix = new int[x.GetLength(0), x.GetLength(1)];
            Array.Copy(x, matrix, x.Length);
        }
        public Matrix(DataGridView dGrV)
        {
            matrix = new int[dGrV.RowCount, dGrV.ColumnCount];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] =Convert.ToInt32( dGrV[j, i].Value);
        }

        //вывод в таблицу
        public void Output(DataGridView dGrV)
        {
            dGrV.RowCount = matrix.GetLength(0);
            dGrV.ColumnCount = matrix.GetLength(1);
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    dGrV[j, i].Value = matrix[i, j];
        }
        public int Max()
        {                    
            return minOrMax((x,y)=>(x>y)); 
        }
        public int Min()
        {
            return minOrMax((x, y) => (x < y));
        }
        // метод, который ищет минимум или максимум
        private int minOrMax(Func<int,int,bool> p)
        {
            int mm = matrix[0, 0];
            foreach (int m in matrix)
                if (p(m,mm)) mm = m;
            return mm;
        }

        public List<int> GetPositiveItems()
        {
            List<int> res = new List<int>();
            foreach (int m in matrix)
                if (m > 0)
                    res.Add(m);
            return res;
        }
    }
}
