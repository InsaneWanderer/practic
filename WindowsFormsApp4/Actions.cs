using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    //Класс действий для работы с базой данных
    class Actions
    {
        // Заполнение ListBox данными из таблицы table базы данных, где столбец name идет как отображаемый элемент, а id как столбец значений
        public static void ListBoxFill(ListBox lb, string table, string id, string name)
        {
            SqlConnection con = DBUtils.GetDBConnection();
            string sql = "SELECT " + id + ", " + name + " FROM " + table;

            try
            {
                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(ds);
                lb.DataSource = ds.Tables[0];
                lb.DisplayMember = name;
                lb.ValueMember = id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        // заполнение DataGridView таблицей контента
        public static void ContentDataGridViewFill(DataGridView dgv)
        {
            dgv.ColumnCount = 14;
            SqlConnection con = DBUtils.GetDBConnection();

            try
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "SELECT COUNT(*) FROM AllContent";
                dgv.RowCount = Convert.ToInt32(cmd.ExecuteScalar());

                ColumnFill(dgv, 0, "Id", "AllContent", "Id", cmd);
                ColumnFill(dgv, 1, "Название", "AllContent", "ContentName", cmd);
                ColumnFill(dgv, 2, "Тип контента", "AllContent", "ContentTypes", "ContentType", "TypeId", "ContentTypeId", cmd);
                ColumnFill(dgv, 3, "Год выхода", "AllContent", "Year", cmd);

                cmd.CommandText = "SELECT (ContentWorkers.Name + ' ' + ContentWorkers.Surname) FROM AllContent JOIN DirectorsAndContent ON DirectorsAndContent.ContentId = AllContent.Id JOIN ContentWorkers ON ContentWorkers.Id = DirectorsAndContent.ContentDirectorId";
                ColumnFill(dgv, 4, "Режиссер", cmd);

                cmd.CommandText = "SELECT STRING_AGG(ContentWorkers.Name + ' ' + ContentWorkers.Surname, ', ') FROM ContentWorkers JOIN ActorsAndContent ON ActorsAndContent.ActorId = ContentWorkers.Id JOIN AllContent ON ActorsAndContent.ContentId = AllContent.Id GROUP BY AllContent.Id";
                ColumnFill(dgv, 5, "Актеры", cmd);

                cmd.CommandText = "SELECT STRING_AGG(Genres.Genre, ', ') FROM Genres JOIN GenreAndContent ON GenreAndContent.GenreId = Genres.Id JOIN AllContent ON GenreAndContent.ContentId = AllContent.Id GROUP BY AllContent.Id";
                ColumnFill(dgv, 6, "Жанры", cmd);
                
                cmd.CommandText = "DECLARE @i INT " +
                    "SET @i = 1 " +
                    "WHILE @i <= (SELECT COUNT(*) FROM AllContent) " +
                    "BEGIN " +
                    "IF(SELECT TOP 1 * FROM(SELECT ContentAccessId FROM AllContent ORDER BY Id OFFSET(@i - 1) ROW) a) IS NULL " +
                    "SELECT 'За деньги' Name; " +
                    "ELSE " +
                    "SELECT SubscriptionTypes.Name FROM AllContent " +
                    "JOIN SubscriptionTypes ON SubscriptionTypes.Id = AllContent.ContentAccessId; " +
                    "SET @i = @i + 1 " +
                    "END";
                DataSet ds = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd.CommandText, con);
                sqlDataAdapter.Fill(ds);

                dgv.Columns[7].HeaderCell.Value = "Доступ";
                for (int i = 0; i < dgv.RowCount; i++) 
                {
                    dgv.Rows[i].Cells[7].Value = ds.Tables[i].Rows[0].ItemArray[0];
                }

                cmd.CommandText = "DECLARE @i INT " +
                    "SET @i = 1 " +
                    "WHILE @i <= (SELECT COUNT(*) FROM AllContent) " +
                    "BEGIN " +
                    "IF (SELECT TOP 1 Price FROM(SELECT Price FROM AllContent ORDER BY Id OFFSET (@i-1) ROW) a) IS NULL " +
                    "SELECT 'По подписке' Name; " +
                    "ELSE " +
                    "SELECT (CONVERT(nvarchar(50), Price) + ' руб') price FROM (SELECT TOP 1 Price FROM(SELECT Price FROM AllContent ORDER BY Id OFFSET (@i-1) ROW) a) p; " +
                    "SET @i = @i + 1 " +
                    "END";
                ds = new DataSet();
                sqlDataAdapter = new SqlDataAdapter(cmd.CommandText, con);
                sqlDataAdapter.Fill(ds);

                dgv.Columns[8].HeaderCell.Value = "Цена";
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    dgv.Rows[i].Cells[8].Value = ds.Tables[i].Rows[0].ItemArray[0];
                }

                cmd.CommandText = "DECLARE @i INT " +
                    "SET @i = 1 " +
                    "WHILE @i <= (SELECT COUNT(*) FROM AllContent) " +
                    "BEGIN " +
                    "IF(SELECT COUNT(CollectionId) FROM CollectionsContent WHERE ContentId = (SELECT TOP 1 Id FROM (SELECT Id FROM AllContent ORDER BY Id OFFSET (@i-1) ROW) a)) < 1 " +
                    "SELECT 'Не состоит в коллекциях' Name; " +
                    "ELSE " +
                    "SELECT STRING_AGG(Collections.Name, ', ') FROM (SELECT TOP 1 Id FROM (SELECT Id FROM AllContent ORDER BY Id OFFSET (@i-1) ROW) a) b " +
                    "JOIN CollectionsContent ON CollectionsContent.ContentId = b.Id " +
                    "JOIN Collections ON CollectionsContent.CollectionId = Collections.Id; " +
                    "SET @i = @i + 1 " +
                    "END";
                ds = new DataSet();
                sqlDataAdapter = new SqlDataAdapter(cmd.CommandText, con);
                sqlDataAdapter.Fill(ds);

                dgv.Columns[9].HeaderCell.Value = "Коллекции";
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    dgv.Rows[i].Cells[9].Value = ds.Tables[i].Rows[0].ItemArray[0];
                }

                ColumnFill(dgv, 10, "Постер", "AllContent", "PosterName", cmd);
                ColumnFill(dgv, 11, "Продолжительность", "AllContent", "Duration", cmd);
                ColumnFill(dgv, 12, "Описание", "AllContent", "Text", cmd);
                ColumnFill(dgv, 13, "Видео", "AllContent", "Video", cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
            finally { con.Close(); }
        }


        //Функция заполнения столбца dataGridView данными из таблицы sql
        private static void ColumnFill(DataGridView dgv, int ColumnIndex, string ColumnName, string Table, string Column, SqlCommand cmd)
        {
            dgv.Columns[ColumnIndex].HeaderCell.Value = ColumnName;

            cmd.CommandText = "SELECT " + Column + " FROM " + Table;

            SqlDataReader SqlRead = cmd.ExecuteReader();

            for (int i = 0; SqlRead.Read(); i++)
            {
                dgv.Rows[i].Cells[ColumnIndex].Value = SqlRead.GetValue(0);
            }

            SqlRead.Close();
        }
        //Заполнение, если имеется таблица для JOIN
        private static void ColumnFill(DataGridView dgv, int ColumnIndex, string ColumnName, string Table, string JoinTable, string Column, string JoinColumn1, string JoinColumn2, SqlCommand cmd)
        {
            dgv.Columns[ColumnIndex].HeaderCell.Value = ColumnName;

            cmd.CommandText = "SELECT " + JoinTable + "." + Column + " FROM " + Table + " JOIN " + JoinTable + " ON " + JoinTable + "." + JoinColumn1 + " = " + Table + "." + JoinColumn2;

            SqlDataReader SqlRead = cmd.ExecuteReader();

            for (int i = 0; SqlRead.Read(); i++)
            {
                dgv.Rows[i].Cells[ColumnIndex].Value = SqlRead.GetValue(0);
            }

            SqlRead.Close();
        }
        //Заполнение по собственной команде
        private static void ColumnFill(DataGridView dgv, int ColumnIndex, string ColumnName, SqlCommand cmd)
        {
            dgv.Columns[ColumnIndex].HeaderCell.Value = ColumnName;

            SqlDataReader SqlRead = cmd.ExecuteReader();

            for (int i = 0; SqlRead.Read(); i++)
            {
                dgv.Rows[i].Cells[ColumnIndex].Value = SqlRead.GetValue(0);
            }

            SqlRead.Close();
        }

    }
}
