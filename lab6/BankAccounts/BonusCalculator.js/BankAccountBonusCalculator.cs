using System;

namespace BonusCalculator.js
{
    public interface IBankAccountBonusCalculator
    {
        int CalculateRefill(int initAmount, int balanceCoefficient, int refillAmount, int reffilCoefficient);
        int CalculateDebit(int initAmount, int balanceCoefficient, int debitAmount, int debitCoefficient);
    }
    public class BankAccountBonusCalculator : IBankAccountBonusCalculator
    {
        public int CalculateRefill(int initAmount, int balanceCoefficient, int refillAmount, int reffilCoefficient)
        {
            return initAmount * balanceCoefficient + refillAmount * reffilCoefficient;
        }

        public int CalculateDebit(int initAmount, int balanceCoefficient, int debitAmount, int debitCoefficient)
        {
            int result = initAmount * balanceCoefficient / balanceCoefficient + debitAmount * debitCoefficient;
            return result < 0 ? 0 : result;
        }
    }
}
