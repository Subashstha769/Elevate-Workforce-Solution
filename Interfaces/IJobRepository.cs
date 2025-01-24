using ISMT23CWeb.Models;

namespace WebLab2024.Interfaces
{

public interface IJobRepository
    {
        bool Create(JobViewModel jvm);
        bool Update (JobViewModel jvm);
        bool Delete (JobViewModel jvm);
        List<JobViewModel> GetAll();

        JobViewModel GetById(int id);
        
    }

}