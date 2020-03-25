using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SeteWebApi.Data
{
	/// <summary>
	/// Clase para la administración de información con la base de datos
	/// </summary>
	public class DbManager
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entidad"></param>
		/// <param name="value"></param>
		/// <param name="field"></param>
		/// <returns></returns>
		public List<object> GetByField(string entidad, string value, string field = "all")
		{
			if (field == "all")
			{
				return GetByQuery(entidad, $" SELECT * FROM {entidad}");
			}
			else
			{
				return GetByQuery(entidad, $" SELECT * FROM {entidad} WHERE {field} = '{value}' ");
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="entidad"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public List<object> GetByQuery(string entidad, string query)
		{
			var lista = new List<object>();

			using (var connection =
				new SqlConnection(ConfigurationManager.ConnectionStrings["seteConnection"].ConnectionString))
			{
				connection.Open();

				using (var command = new SqlCommand(query, connection))
				{
					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
							switch (entidad)
							{
								//case "alarmas":
								//	lista.Add(TipoAlarma.ParseToReader(reader));
								//	break;
								//case "responsables":
								//    lista.Add(Responsable.ParseToReader(reader));
								//    break;
								//case "departamentos":
								//    lista.Add(Departamento.ParseToReader(reader));
								//    break;
								//case "sucursales":
								//    lista.Add(Sucursal.ParseToReader(reader));
								//    break;
								//case "listasDestinos":
								//    lista.Add(ListaDestino.ParseToReader(reader));
								//    break;
								//case "guiasTelefonicas":
								//    lista.Add(GuiaTelefonica.ParseToReader(reader));
								//    break;
								//case "extensiones":
								//    lista.Add(Extension.ParseToReader(reader));
								//    break;
								//case "tipoAlarmas":
								//    lista.Add(TipoAlarma.ParseToReader(reader));
								//    break;
								//case "autorizaciones":
								//    lista.Add(Autorizacion.ParseToReader(reader));
								//    break;
								//case "registrosLlamadas":
								//    lista.Add(RegistroLlamada.ParseToReader(reader));
								//    break;
								default:
									throw new Exception("No se ha definido la entidad a utilizar");
							}
						connection.Close();
					}
				}
			}

			return lista;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		public int Save(string query)
		{
			int result;

			using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["seteConnection"].ConnectionString))
			{
				connection.Open();

				using (var command = new SqlCommand(query, connection))
				{
					result = Convert.ToInt32(command.ExecuteScalar());
				}

				connection.Close();
			}

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="procedureName"></param>
		/// <param name="entidad"></param>
		/// <param name="Parameterlist"></param>
		/// <returns></returns>
		public List<object> ExecuteProcedure(string procedureName, string entidad, SqlParameter[] Parameterlist)
		{
			var lista = new List<object>();

			using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["seteConnection"].ConnectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(procedureName, connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					if (Parameterlist != null)
					{
						command.Parameters.AddRange(Parameterlist);
					}
					try
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								// en caso de operaciones CRUD, devueleve 0 si es exitoso, numeros negativos significan errores
								int valor = Int32.Parse(reader[0].ToString());
								if (valor <= 0)
								{
									lista.Add(valor);
								}
								else
								{
									switch (entidad)
									{
										//case "alarmas":
										//	lista.Add(Alarma.ParseToReader(reader));
										//	break;
										//case "responsables":
										//	lista.Add(Responsable.ParseToReader(reader));
										//	break;
										//case "departamentos":
										//	lista.Add(Departamento.ParseToReader(reader));
										//	break;
										//case "registrosLlamadas":
										//	lista.Add(RegistroLlamada.ParseToReader(reader));
										//	break;
										//case "roles":
										//	lista.Add(Rol.ParseToReader(reader));
										//	break;
										//case "tipoAlarmas":
										//	lista.Add(TipoAlarma.ParseToReader(reader));
										//	break;
										//case "distribucion":
										//	lista.Add(DistribucionLlamada.ParseToReader(reader));
										//	break;
										//case "extensiones":
										//	lista.Add(Extension.ParseToReader(reader));
										//	break;
										//case "reportes":
										//	lista.Add(Reporte.ParseToReader(reader));
										//	break;
										//case "sucursales":
										//	lista.Add(Sucursal.ParseToReader(reader));
										//	break;
										//case "guiaTelefonica":
										//	lista.Add(GuiaTelefonica.ParseToReader(reader));
											//break;
										default:
											throw new Exception("No se ha definido la entidad a utilizar");
									}
								}
							}

						}
					}
					catch (Exception e)
					{
						lista.Add("Error:" + e);
					}

				}
				return lista;
			}


		}
	}
}