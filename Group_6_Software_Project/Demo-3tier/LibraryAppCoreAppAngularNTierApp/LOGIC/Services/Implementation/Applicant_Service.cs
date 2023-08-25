using DAL.Entities;
using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Applicant;
using System;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Applicant Data
    /// </summary>
    public class Applicant_Service : IApplicant_Service
    {
        //Reference to our crud functions
        private ICRUD _crud = new CRUD();

        /// <summary>
        /// Adds a single applicant record to the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="birthday"></param>
        /// <param name="email"></param>
        /// <param name="phone_number"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Applicant_ResultSet>> AddSingleApplicant(string name, string surname, DateTime birthday, string email, string phone_number)
        {
            Generic_ResultSet<Applicant_ResultSet> result = new Generic_ResultSet<Applicant_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Applicant
                Applicant Applicant = new Applicant
                {
                    Applicant_Name = name,
                    Applicant_Surname = surname,
                    Applicant_BirthDate = birthday,
                    Contact_Email = email,
                    Contact_Number = phone_number
                };

                //ADD Applicant TO DB
                Applicant = await _crud.Create<Applicant>(Applicant);

                //MANUAL MAPPING OF RETURNED Applicant VALUES TO OUR Applicant_ResultSet
                Applicant_ResultSet applicantAdded = new Applicant_ResultSet
                {
                    id = Applicant.ApplicantID,
                    name = Applicant.Applicant_Name,
                    surname = Applicant.Applicant_Surname,
                    birthday = Applicant.Applicant_BirthDate,
                    email = Applicant.Contact_Email,
                    phone_number = Applicant.Contact_Number,
                    submission_date = Applicant.Applicant_CreationDate
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Your child {0} was registered successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Applicant_Service: AddSingleApplicant() method executed successfully.";
                result.result_set = applicantAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for your child. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Applicant_Service: AddSingleApplicant(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Finds and returns the applicant for the specifed applicant id.
        /// </summary>
        /// <param name="applicant_id"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Applicant_ResultSet>> GetApplicantById(Int64 applicant_id)
        {
            Generic_ResultSet<Applicant_ResultSet> result = new Generic_ResultSet<Applicant_ResultSet>();
            try
            {
                //GET Applicant FROM DB
                Applicant Applicant = await _crud.Read<Applicant>(applicant_id);

                //MANUAL MAPPING OF RETURNED Applicant VALUES TO OUR Applicant_ResultSet
                Applicant_ResultSet applicantReturned = new Applicant_ResultSet
                {
                    id = Applicant.ApplicantID,
                    name = Applicant.Applicant_Name,
                    surname = Applicant.Applicant_Surname,
                    birthday = Applicant.Applicant_BirthDate,
                    email = Applicant.Contact_Email,
                    phone_number = Applicant.Contact_Number,
                    submission_date = Applicant.Applicant_CreationDate
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Applicant {0} was found successfully", applicantReturned.name);
                result.internalMessage = "LOGIC.Services.Implementation.Applicant_Service: GetApplicantById() method executed successfully.";
                result.result_set = applicantReturned;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed find the applicant you are looking for.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Applicant_Service: AddSingleApplicant(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updates the applicants details with the supplied information.
        /// </summary>
        /// <param name="applicant_id"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="birthday"></param>
        /// <param name="email"></param>
        /// <param name="phone_number"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Applicant_ResultSet>> UpdateApplicant(Int64 applicant_id, string name, string surname, DateTime birthday, string email, string phone_number)
        {
            Generic_ResultSet<Applicant_ResultSet> result = new Generic_ResultSet<Applicant_ResultSet>();
            try
            {
                Applicant ApplicantToUpdate = new Applicant
                {
                    ApplicantID = applicant_id,
                    Applicant_Name = name,
                    Applicant_Surname = surname,
                    Applicant_BirthDate = birthday,
                    Contact_Email = email,
                    Contact_Number = phone_number,
                    Applicant_ModifiedDate = DateTime.UtcNow
                };
                //UPDATE Applicant FROM DB
                ApplicantToUpdate = await _crud.Update<Applicant>(ApplicantToUpdate, applicant_id);

                //MANUAL MAPPING OF UPDATED Applicant VALUES TO OUR Applicant_ResultSet
                Applicant_ResultSet applicantUpdated = new Applicant_ResultSet
                {
                    id = ApplicantToUpdate.ApplicantID,
                    name = ApplicantToUpdate.Applicant_Name,
                    surname = ApplicantToUpdate.Applicant_Surname,
                    birthday = ApplicantToUpdate.Applicant_BirthDate,
                    email = ApplicantToUpdate.Contact_Email,
                    phone_number = ApplicantToUpdate.Contact_Number,
                    submission_date = ApplicantToUpdate.Applicant_CreationDate
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Applicant {0} was updated successfully", applicantUpdated.name);
                result.internalMessage = "LOGIC.Services.Implementation.Applicant_Service: UpdateApplicant() method executed successfully.";
                result.result_set = applicantUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update the supplied applicant.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Applicant_Service: UpdateApplicant(): {0}", exception.Message);
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }
    }
}
