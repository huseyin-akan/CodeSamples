using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Design_Patterns.Middleware.HusoMiddleware
{
    //NOT: Bunu daha iyi olduğu için değil, anlaması daha kolay olduğu için yazdık. Üst klasördeki yapı çok daha iyi.
    public class HusoPipeBuilder
    {
        readonly Action<string> _mainAction;
        readonly List<HusoPipe> _pipeline;

        public HusoPipeBuilder(Action<string> mainAction)
        {
            _mainAction = mainAction;
            _pipeline = new List<HusoPipe>();
        }

        public HusoPipeBuilder AddPipe(HusoPipe pipe)
        {
            _pipeline.Add(pipe);
            return this;
        }

        public Action<string> Build()
        {
            //Pipeline'da en az 1 eleman olmalı
            if (_pipeline.Count == 0) throw new Exception("At least one pipe should be added to the pipeline");

            //En son eklenen pipe'ın handle edilecek metoduna ana metodun referansını veriyoruz.
            _pipeline[^1]._action = _mainAction;

            //İç içe geçecek şekilde sondan başa doğru handle ediecek metoda bir sonrakinin Handle metot referansını veriyoruz.
            for (int i = _pipeline.Count - 2; i >= 0; i--)
            {
                _pipeline[i]._action = _pipeline[i + 1].Handle;
            }

            //İlk pipe'ın Handle metot referansını dönüyoruz. Bu metot execute edildiğinde sırayla hepsi çalışacak.
            return _pipeline[0].Handle;
        }
    }
}
