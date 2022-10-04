using SchoolApi.Domain.ModelView;

namespace SchoolApi.Domain.Entity
{
    public abstract class BaseEntity
    {        
        public virtual int Id { get; set; }
        public virtual bool Active { get; set; }
        public virtual int CreateBy { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual int ModifBy { get; set; }
        public virtual DateTime ModifDate { get; set; }
        public void CreateEntity(UserProfile user)
        {
            Active = true;
            CreateBy = user.Id;
            ModifDate=CreateDate = DateTime.Now;
            ModifBy = user.Id;
        }
        public void UpdateEntity(UserProfile user, int createId,DateTime createDate)
        {
            CreateBy = createId;
            CreateDate = CreateDate;
            ModifDate =  DateTime.Now;
            ModifBy = user.Id;
        }
    }
}
