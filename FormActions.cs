using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timetable
{
    //Класс методов, связанных с формами и их элементами
    class FormActions
    {
        //Переходит с текущей формы на заданную форму
        public static void GoTo(Form to)
        {
            Form.ActiveForm.Hide();
            to.Show();
        }
        //Получает индекс предмета ListBox по его значению
        public static int GetIndexOf(ListBox lb, object value)
        {
            int i;
            for (i = 0; i < lb.Items.Count; i++)
            {
                lb.SelectedIndex = i;
                if (lb.SelectedValue.ToString() == value.ToString())
                    break;
            }
            lb.SelectedItems.Clear();
            return i;
        }
    }
}
