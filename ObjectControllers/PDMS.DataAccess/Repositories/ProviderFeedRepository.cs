using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PDMS.DataAccess.DBHelpers;
using PDMS.DataAccess.Models;

namespace PDMS.DataAccess.Repositories
{
    public class ProviderFeedRepository : Interfaces.IProviderFeedRepository
    {
        private readonly SqlDataAccessHelper _dbHelper;

        public ProviderFeedRepository()
        {
            _dbHelper = new SqlDataAccessHelper();
        }

        public List<REGProviderFeedModel> GetProviderFeed(SqlParameter[] parameters)
        {
            return _dbHelper.ExecuteReader("usp_SelectREG_Provider_Feed", parameters, MapSelectREGProviderFeedModel).ToList();
        }

        public ProviderNotesModelResult GetHistoricNotes(SqlParameter[] parameters)
        {
            return ExecuteSelectProviderNotesModel(parameters);
        }

        private REGProviderFeedModel MapSelectREGProviderFeedModel(SqlDataReader reader)
        {
            return new REGProviderFeedModel()
            {
                reg_provider_feed_id = reader.GetNullableInt("reg_provider_feed_id"),
                reg_id = reader.GetNullableInt("reg_id"),
                Notes_Date = reader.GetNullableDateTime("Notes_Date"),
                InitiatedBy = reader.GetNullableString("InitiatedBy") ?? string.Empty,
                person_reviewed_by = reader.GetNullableString("person_reviewed_by") ?? string.Empty,
                enrollment_type = reader.GetNullableString("enrollment_type") ?? string.Empty,
                Final_Disposition = reader.GetNullableString("Final_Disposition") ?? string.Empty,
                HistoricTmNotes = reader.GetNullableString("HistoricTmNotes") ?? string.Empty,
                InitiatedByUserId = reader.GetNullableGuid("InitiatedByUserId"),
                person_reviewed_by_userid = reader.GetNullableGuid("person_reviewed_by_userid"),
                processid = reader.GetNullableInt("processid"),
                ProviderFeedProcessId = reader.GetNullableInt("ProviderFeedProcessId")
            };
        }


        private ProviderNotesModelResultSet1 MapSelectProviderNotesModelResultSet1(SqlDataReader reader)
        {
            return new ProviderNotesModelResultSet1()
            {
                reg_id = reader.GetNullableInt("reg_id"),
                provider_note_type = reader.GetNullableString("provider_note_type") ?? string.Empty,
                workflow_event_type = reader.GetNullableString("workflow_event_type") ?? string.Empty,
                NOTE_TEXT = reader.GetNullableString("NOTE_TEXT") ?? string.Empty,
                UserName = reader.GetNullableString("UserName") ?? string.Empty,
                NOTE_DATE_TIME = reader.GetNullableDateTime("NOTE_DATE_TIME"),
                screen = reader.GetNullableString("screen") ?? string.Empty
            };
        }

        private ProviderNotesModelResultSet2 MapSelectProviderNotesModelResultSet2(SqlDataReader reader)
        {
            return new ProviderNotesModelResultSet2()
            {
            };
        }

        private ProviderNotesModelResult ExecuteSelectProviderNotesModel(SqlParameter[] parameters)
        {
            var result = new ProviderNotesModelResult();
            using (var connection = new SqlConnection(_dbHelper.ConnectionString))
            {
                using (var command = new SqlCommand("usp_SelectProvider_Notes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null) command.Parameters.AddRange(parameters);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        result.ResultSet1 = new List<ProviderNotesModelResultSet1>();
                        while (reader.Read()) result.ResultSet1.Add(MapSelectProviderNotesModelResultSet1(reader));
                        reader.NextResult();
                        result.ResultSet2 = new List<ProviderNotesModelResultSet2>();
                        while (reader.Read()) result.ResultSet2.Add(MapSelectProviderNotesModelResultSet2(reader));
                    }
                }
            }
            return result;
        }


    }
}
