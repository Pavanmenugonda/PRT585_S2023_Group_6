using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using DAL.Entities;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Grade;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Grade Data
    /// </summary>
    public class Grade_Service : IGrade_Service
    {
        //Reference to our crud functions
        private ICRUD _crud = new CRUD();

        /// <summary>
        /// Adds an new Grade to the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="grade_number"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Grade_ResultSet>> AddSingleGrade(string name, int grade_number, int capacity)
        {
            Generic_ResultSet<Grade_ResultSet> result = new Generic_ResultSet<Grade_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Grade
                Grade Grade = new Grade
                {
                    Grade_Name = name,
                    Grade_Number = grade_number,
                    Grade_Capacity = capacity
                };

                //ADD Grade TO DB
                Grade = await _crud.Create<Grade>(Grade);

                //MANUAL MAPPING OF RETURNED Grade VALUES TO OUR Grade_ResultSet
                Grade_ResultSet gradeAdded = new Grade_ResultSet
                {
                    id = Grade.GradeID,
                    name = Grade.Grade_Name,
                    grade_number = Grade.Grade_Number,
                    capacity = Grade.Grade_Capacity
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied grade {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Grade_Service: AddSingleGrade() method executed successfully.";
                result.result_set = gradeAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the grade supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Grade_Service: AddSingleGrade(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Gets all Grades that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Grade_ResultSet>>> GetAllGrades()
        {
            Generic_ResultSet<List<Grade_ResultSet>> result = new Generic_ResultSet<List<Grade_ResultSet>>();
            try
            {
                //GET ALL GRADES
                List<Grade> Grades = await _crud.ReadAll<Grade>();
                //MAP DB GRADE RESULTS
                result.result_set = new List<Grade_ResultSet>();
                Grades.ForEach(dg => {
                    result.result_set.Add(new Grade_ResultSet {
                        id = dg.GradeID,
                        name = dg.Grade_Name,
                        grade_number = dg.Grade_Number,
                        capacity = dg.Grade_Capacity
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All grades obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Grade_Service: GetAllGrades() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required grades from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Grade_Service: GetAllGrades(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updates the specified grades value/s
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="grade_number"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Grade_ResultSet>> UpdateGrade(Int64 id, string name, int grade_number, int capacity)
        {
            Generic_ResultSet<Grade_ResultSet> result = new Generic_ResultSet<Grade_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Grade
                Grade Grade = new Grade
                {
                    GradeID = id,
                    Grade_Name = name,
                    Grade_Number = grade_number,
                    Grade_Capacity = capacity,
                    Grade_ModifiedDate = DateTime.UtcNow
                };

                //ADD Grade TO DB
                Grade = await _crud.Update<Grade>(Grade, id);

                //MANUAL MAPPING OF RETURNED Grade VALUES TO OUR Grade_ResultSet
                Grade_ResultSet gradeUpdated = new Grade_ResultSet
                {
                    id = Grade.GradeID,
                    name = Grade.Grade_Name,
                    grade_number = Grade.Grade_Number,
                    capacity = Grade.Grade_Capacity
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied grade {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Grade_Service: UpdateGrade() method executed successfully.";
                result.result_set = gradeUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the grade supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.UpdateGrade: AddSingleGrade(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}
