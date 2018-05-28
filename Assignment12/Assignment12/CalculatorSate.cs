using System;
namespace SimpleCalculator
{
    /// <summary>
    ///  این کلاس وضعیت مادر است 
    ///  برای هر وضعیتی اگر یکی از 
    ///  Event ها
    ///  مثلا
    ///  EnterEqual/...
    ///  را 
    ///  override
    ///  نکنیم به طور پیش فرض کاری انجام نمیدهد و در وضعیت فعلی باقی میماند.
    ///  #6 لطفا!
    /// </summary>
    /// 
    /// 
    //میشود این کلاس را از حالت abstract خارج کرد و برای آن تست یونیت نوشت
    //ولی به دلیل اینکه باید از این کلاس یک object ساخته و تک تک متود هارا صدا زده و تست کرد
    //احساس میکنم کار بیهوده ای است و تست جالبی نمیشود لطفا اگر به نظر شما تست کردن این کلاس لازم است به من بگویید تا تست کنم
    //ممنون
    public abstract class CalculatorState : IState
    {
        public Calculator Calc { get;  }
        public CalculatorState(Calculator calc) => this.Calc = calc;
        public virtual IState EnterEqual() => this;
        public virtual IState EnterZeroDigit() => this;
        public virtual IState EnterNonZeroDigit(char c) => this;        
        public virtual IState EnterOperator(char c) => this;
        public virtual IState EnterPoint() => this;

        protected IState ProcessOperator(IState nextState, char? op = null)
        {
            try
            {
                this.Calc.Evalute();
                this.Calc.UpdateDisplay();
                this.Calc.PendingOperator = op;
                return nextState;
            }
            catch (Exception e)
            {
                this.Calc.DisplayError(e.Message);
                return new ErrorState(this.Calc);
            }
        }
    }
}