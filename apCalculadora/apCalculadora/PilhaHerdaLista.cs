using System;

public class PilhaHerdaLista<Dado> : ListaSimples<Dado>, IStack<Dado> 
                                     where Dado : IComparable<Dado>
{
    int qtd = 0;

  public PilhaHerdaLista() : base()
  { 
    // construtor
  }
  public void Empilhar(Dado o)
  {
    NoLista<Dado> novoNo = new NoLista<Dado>(o, null);
    InserirAntesDoInicio(novoNo);
  }
  public Dado OTopo() 
  {
    Dado o;
    if (EstaVazia())
       throw new PilhaVaziaException("Underflow da pilha");
    o = Primeiro.Info;
    return o;
  }
  public Dado Desempilhar() 
  {
    if (EstaVazia())
       throw new PilhaVaziaException("Underflow da pilha");
    Dado o = Primeiro.Info;
    RemoverNo(null, Primeiro);  // remove o primeiro nó da lista ligada herdada
    return o; // devolve o objeto que estava no topo
  }

  public int Tamanho()
  {
        return qtd;
        //return QuantosNos;
    }

  public new bool EstaVazia()
  {
    return base.EstaVazia;
  }

    public bool EstaEmOrdem(PilhaHerdaLista<Dado> pilha) //Verificar se não tem sinal seguido de sinal e se todos os parênteses foram abertos e fechados igualmente
    {
        bool estaOrdenada = false;

        return estaOrdenada;
    }

    public PilhaHerdaLista<Dado> ParaPosfixa()
    {//pilha está em formato infixa

       PilhaHerdaLista<Dado> aux = this;
       PilhaHerdaLista<Dado> posfixa = null;

        for (int i = 0; i < this.Tamanho(); i++)
        {
            posfixa.Empilhar(aux.OTopo());
            aux.Desempilhar();
        }                    

        //aqui, posfixa guarda a pilha ao contrario

       


        return posfixa;
    }
}
