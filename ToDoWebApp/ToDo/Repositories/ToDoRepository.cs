using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ToDo
{
    public class ToDoRepository : IToDoRepository
    {
        public string connectionString;

        public ToDoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Task AddTask(string description)
        {
            Task response = null;
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("ToDo_AddTaskByDescription", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Description", description);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        response = new Task {
                            Id = (int)reader["Id"],
                            Description = reader["Description"].ToString(),
                            IsCompleted = (bool)reader["IsCompleted"],
                            LastUpdated = (DateTime)reader["LastUpdated"]
                        };
                    }
                }
                catch (Exception ex)
                {
                    //do nothing
                } 
            }
            return response;
        }

        public void DeleteTask(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                SqlCommand command = new SqlCommand("ToDo_DeleteTaskById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                try
                {
                    connection.Open();
                    command.ExecuteScalar();
                } catch (Exception ex) 
                {
                    //do nothing
                }
            }
        }

        public List<Task> GetTasks()
        {
            List<Task> response = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("ToDo_GetAllTasks", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    response = new List<Task>();
                    while (reader.Read())
                    {
                        response.Add( new Task
                        {
                            Id = (int)reader["Id"],
                            Description = reader["Description"].ToString(),
                            IsCompleted = (bool)reader["IsCompleted"],
                            LastUpdated = (DateTime)reader["LastUpdated"]
                        });
                    }
                }
                catch (Exception ex)
                {
                    //do nothing
                }
            }
            return response;
        }

        public Task ToggleComplete(int Id)
        {
            Task response = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("ToDo_ToggleCompleteById", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        response = new Task
                        {
                            Id = (int)reader["Id"],
                            Description = reader["Description"].ToString(),
                            IsCompleted = (bool)reader["IsCompleted"],
                            LastUpdated = (DateTime)reader["LastUpdated"]
                        };
                    }
                }
                catch (Exception ex)
                {
                    //do nothing
                }
            }
            return response;
        }

    }
}
