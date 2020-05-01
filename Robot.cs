using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROMidtermPractice 
{
    abstract class Robot : IComparable<Robot>
    {
        protected Guid guid_;
        protected String nickname_;
        protected String model_;

        public int CompareTo(Robot obj)
        {
            if (RobotSortMechanism.sortType == SORT_TYPE.SORT_BASED_ON_NICKNAME)
            {
                return nickname_.CompareTo(obj.nickname_);
            }

            return model_.CompareTo(obj.model_);
            
        }
    }

    public static class RobotSortMechanism

    {

        public static SORT_TYPE sortType { set; get; } =

                SORT_TYPE.SORT_BASED_ON_MODEL | SORT_TYPE.SORT_BASED_ON_NICKNAME;

    }



    [Flags]

    public enum SORT_TYPE

    {

        SORT_BASED_ON_NICKNAME = 0,

        SORT_BASED_ON_MODEL = 1,

        SORT_BASED_ON_ID = 2

    }
}