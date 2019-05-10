using System;

public interface IStack<Dado> where Dado : IComparable<Dado>
{//Interface herdada
  void Empilhar(Dado elemento);
  Dado Desempilhar();
  Dado OTopo();
  bool EstaVazia();
  int Tamanho();
}
