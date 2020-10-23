using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalInterMachine.InterfaceMachine
{
    struct UserAnswer
    {
        public bool? Answer { private set; get; }

        public string SelectedAnswer {private set; get; }
        /// <summary>
        /// Если варианты ответа да/нет
        /// </summary>
        /// <param name="answer">да/нет (true/false соответсвенно)</param>
        public UserAnswer(bool answer)
        {
            Answer = answer;
            SelectedAnswer = "";
        }
        /// <summary>
        /// Если варианты ответа НЕ да/нет
        /// </summary>
        /// <param name="selectedAnswer">Выбранный пользователем вариант ответа</param>
        public UserAnswer (string selectedAnswer)
        {
            Answer = null;
            SelectedAnswer = selectedAnswer;
        }
    }
}
