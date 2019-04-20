using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_7_LS_And_CP_models
{
    public class GraphUtils
    {
        public static void FillIdList(List<int> idList, int id, int value)
        {
            for (int i = 0; i < value; i++)
            {
                idList.Add(id);
            }
        }
    }
}
