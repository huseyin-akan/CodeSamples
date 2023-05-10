using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeSamples.Design_Patterns.Middleware
{
    public class PipeBuilder
    {
        Action<string> _mainAction;
        List<Type> _pipeTypes;

        public PipeBuilder(Action<string> mainAction)
        {
            _mainAction = mainAction;
            _pipeTypes = new List<Type>();
        }

        //Eklenen middleware'ları listeye alıyoruz.
        public PipeBuilder AddPipe(Type pipeType)
        {
            var isPipe = pipeType.GetTypeInfo().IsSubclassOf(typeof(Pipe));
            if (!isPipe)
            {
                throw new Exception("It's not a pipe you are trying to add!!");
            }
            _pipeTypes.Add(pipeType);
            return this;
        }

        private Action<string> CreatePipe(int index)
        {
            // Burayı anlayana kadar canım çıktı :) 
            // Aslında basit. Recursive olarak tek tek eklenen Pipe'ların instance'larını oluşturuyoruz.
            // Her bir instance yapı gereği bir sonraki istance'ın Handle metodunu kendi _action propunda tutacak.

            // Son pipe değilse, recursive olarak sonraki pipe'a git
            // En son pipe'a gelince onun Handle metodunu al ve sondaki Pipe'ın constructor'ına gönder.
            // Activator burda gelen handle parametresini ctor içerisine gönderiyor basitçe
            // Sonra da kendi Handle metodunu önceki Pipe'a gönderiyor.
            // O da kendi _action propuna yine Activator ile gelen Handle metodunu eklicek.
            if (index < _pipeTypes.Count -1)
            {
                var childPipeHandle = CreatePipe(index + 1);
                var pipe = Activator.CreateInstance(_pipeTypes[index], childPipeHandle) as Pipe;
                return pipe.Handle;
            }
            else
            {
                var finalPipe = Activator.CreateInstance(_pipeTypes[index], _mainAction) as Pipe ;
                return finalPipe.Handle;
            }
            //Böylece iç içe birbirlerini wrap'lemiş fonksiyonlar silsilesi oluşmuş oluyor. İlki MiddlewareTester'daki gibi execute ettiğimizde sırayla hepis çalışır hale gelmiş olucak. HARİKA bir yapı. BAYILDIM.
        }

        public Action<string> Build()
        {
            return CreatePipe(0);
        }
    }
}
