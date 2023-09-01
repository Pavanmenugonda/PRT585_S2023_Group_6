using DAL.DataContext;
using DAL.Entities;
using DAL.Functions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Specific
{
    public class Application_Operations: IApplication_Operations
    {
        /// <summary>
        /// Creates both the applicant and application in one method call. It does this by using transactions.
        /// </summary>
        /// <param name="gradeId"></param>
        /// <param name="applicationStatusId"></param>
        /// <param name="schoolYear"></param>
        /// <param name="firstName"></param>
        /// <param name="surname"></param>
        /// <param name="birthDate"></param>
        /// <param name="email"></param>
        /// <param name="contactNumber"></param>
        /// <returns>Application Model Including the Applicant</returns>
        public async Task<Application> AddFullApplication(Int64 gradeId, Int64 applicationStatusId, Int32 schoolYear, string firstName, string surname, DateTime birthDate, string email, string contactNumber)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    using (var transaction = await context.Database.BeginTransactionAsync())
                    {
                        //Nested Try-Catch for transaction...
                        try
                        {
                            //1.) SO LETS ADD THE APPLICANT FIRST 
                            var applicant = new Applicant
                            {
                                Applicant_Name = firstName,
                                Applicant_Surname = surname,
                                Applicant_BirthDate = birthDate,
                                Contact_Email = email,
                                Contact_Number = contactNumber
                            };
                            var trackingApplicant = await context.Applicants.AddAsync(applicant);
                            //NOW COMMIT TO DB SO WE CAN GET Applicant PRIMARY KEY
                            await context.SaveChangesAsync();

                            //2.) NOW THAT WE HAVE THE Applicant_ID WE CAN NOW ADD THE APPLICATION
                            var application = new Application
                            {
                                ApplicantID = applicant.ApplicantID,
                                ApplicationStatusID = applicationStatusId,//Status must be Submitted
                                GradeID = gradeId,
                                SchoolYear = schoolYear

                            };
                            var trackingApplication = await context.Applications.AddAsync(application);
                            await context.SaveChangesAsync();
                            //Commit both transactions - That being Adding of the Applicant and the Application
                            await transaction.CommitAsync();
                            application.Applicant = applicant;
                            //BOTH OBJECTS ARE PRESENT
                            return application;
                        }
                        catch
                        {
                            //There was an error so both transactions were rolled back (Adding Applicant and Adding Application rolled back)
                            await transaction.RollbackAsync();
                            throw;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Application>> GetApplicationsByApplicantId(Int64 applicantId)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    List<Application> Applications = await context.Applications.Include(a => a.Applicant).OrderBy(a => a.SchoolYear).Where(a => a.ApplicantID == applicantId).ToListAsync();

                    return Applications;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
