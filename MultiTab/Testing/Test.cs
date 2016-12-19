using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing
{
    public class Test
    {
        //реализация шаблона Одиночка (Singletone)
        static Test instance=new Test();
        private Test()
        {
            timer.Tick += OnTick;
            timer.Interval = 1000;
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (Mode==TestMode.Exam && (DateTime.Now - time).TotalMinutes >= TimeTest)
            {
                Stop();
            }
        }
      
        public static Test Get()
        {
            return instance;
        }
        //настройки теста
        public TestMode Mode { get;set;} //режим - экзамен или тренировка
        public int TimeTest { get; set; }//время, которое отводится на тест
        public int QuestionCountExam { get; set; }//количество вопросов в режиме экзамена
        public int MinNumber { get; set; }
        public int MaxNumber { get; set; }

        public IGenerator Generator { get; set; }//объект-генератор вопросов

        //поля 
        Timer timer=new Timer();
        int questionCount; //количество вопросов
        int correctAnswerCount;//количество правильных ответов
        TestState state;//состояние -работает тест или остановлен
        DateTime time;//текущее время

        public int QuestionCount { get { return questionCount; } }
        public int CorrectAnswerCount { get { return correctAnswerCount; } }
        public TestState State
        { 
            get { return state; } 
        }
        //конструктор
       
        public void Run()
        {
            state = TestState.Run;
            questionCount = 0;
            correctAnswerCount = 0;
            time = DateTime.Now;
            if (Mode == TestMode.Exam)
                timer.Start();
        }
        public string GetQuestion()//выдача вопросов   ИСПРАВИТЬ изменение ДИАПАЗОНА
        {
            if (State == TestState.Run)
            {
                if (Mode == TestMode.Exam && questionCount == QuestionCountExam)
                    return "Все!";
                questionCount++;
                return Generator.GetQuestion();
            }
            throw new Exception("тестирование завершено");
        }
        
        public string CheckAnswer(string answer)
        {
            string result = "";
            if(answer==Generator.GetCorrectAnswer())
            {
                result = "Молодец, это правильный ответ";
                correctAnswerCount++;

            }
            else
            {
                if(Mode==TestMode.Trening)
                {
                    result = "это неправильный ответ, правильный ответ - " + Generator.GetCorrectAnswer();
                }
            }
            return result;
        }

     public void Stop()
        {
            timer.Stop();
            state = TestState.Stop;
            
        }

        public string Result()
     {
         return "Всего вопросов: " + questionCount + "\n Правильных ответов: " + correctAnswerCount + "\n Затраченное время " + (DateTime.Now - time).TotalMinutes;
     }

        public List<string> GetHelp()
        {
            return Generator.GetAllAnswers();
        }

    }
}
