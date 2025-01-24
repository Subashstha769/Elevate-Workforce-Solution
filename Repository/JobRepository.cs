using ISMT23CWeb.Models;
using SQLitePCL;
using WebLab2024.Interfaces;


namespace WebLab2024.Repository
{

    public class JobRepository : IJobRepository

    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context;

        }
        public bool Create(JobViewModel jvm)
        {
            try
            {
                Job j = new Job();


                j.Title = jvm.Title;
                j.Description = jvm.Description;
                j.Salary = jvm.Salary;
                j.IsActive = jvm.IsActive;
                j.CreateDate = DateTime.Now;
                j.AddedById = jvm.AddedById;


                _context.Jobs.Add(j);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }





        }

        public bool Delete(JobViewModel jvm)
        {
            var job =_context.Jobs.FirstOrDefault(x => x.Id == jvm.Id);
            if(job !=null)
            {
                _context.Jobs.Remove(job);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<JobViewModel> GetAll()
        {
            var jobs = _context.Jobs.ToList();
            if (jobs.Any())
            {


                var result = jobs.Select(x => new JobViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Salary = x.Salary,
                    IsActive = x.IsActive



                });
                return result.ToList();
            }
            return new List<JobViewModel>();



        }

        public bool Update(JobViewModel jvm)
        {
            try
            {
                Job j = new Job();

                j.Id = jvm.Id;
                j.Title = jvm.Title;
                j.Description = jvm.Description;
                j.Salary = jvm.Salary;
                j.IsActive = jvm.IsActive;
                j.AddedById = jvm.AddedById;
                _context.Jobs.Update(j);
                _context.SaveChanges();

                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public JobViewModel GetById(int id)
        {
            var job = _context.Jobs.FirstOrDefault(x => x.Id == id);



            if (job != null)
            {
                var result = new JobViewModel()
                {
                    Id = job.Id,
                    Salary = job.Salary,
                    Title = job.Title,
                    Description = job.Description,
                    IsActive = job.IsActive
                };


                return result;


            }


            throw new NotImplementedException();
        }


    }

}