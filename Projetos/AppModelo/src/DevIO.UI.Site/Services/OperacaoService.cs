using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Services
{
    public class OperacaoService
    {
        public IOperacaoTransiente Transiente { get; }
        public IOperacaoScopped Scopped { get; }
        public IOperacaoSingleton Singleton { get; }
        public IOperacaoSingletonInstance SingletonInstance { get; }
        
        public OperacaoService(IOperacaoTransiente transiente, 
            IOperacaoScopped scopped,
            IOperacaoSingleton singleton,
            IOperacaoSingletonInstance singletonInstance)
        {
            Transiente = transiente;
            Scopped = scopped;
            Singleton = singleton;
            SingletonInstance = singletonInstance;
        }
    }

    public class Operacao : IOperacaoTransiente,
        IOperacaoScopped,
        IOperacaoSingleton,
        IOperacaoSingletonInstance
    {
        public Guid OperacaoId { get; private set; }

        public Operacao() : this(Guid.NewGuid())
        {
        }

        public Operacao(Guid id)
        {
            OperacaoId = id;
        }
    }

    public interface IOperacao
    {
        Guid OperacaoId { get; }
    }

    public interface IOperacaoTransiente : IOperacao {}
    public interface IOperacaoScopped : IOperacao {}
    public interface IOperacaoSingleton : IOperacao {}
    public interface IOperacaoSingletonInstance : IOperacao {}
}
