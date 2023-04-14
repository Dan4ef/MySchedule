namespace MyScheduler.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        
       
        public int? GroupScheduleId { get; set; }//UPDATE
                                                 //додали ось це для зв'язку один до одного
                                                 //між групою і розкладом
                                                 //раніше ключ був тільки у розкладу і це неправильно
        public Schedule? GroupSchedule { get; set; } //вже було, дописали ? - nullable 
    }
}
//teachers & subjects - те саме зробити
//створити CreationModels для кожної моделі - так грамотніше, без доступу до id,
//id має генеруватися самостійно, не вводити його нізащо, як би не хотілося
//для всіх замінити у вьюшках згенерованих до Models моделі на відповідні CreationModels
//де йде створення екземпляру моделі 