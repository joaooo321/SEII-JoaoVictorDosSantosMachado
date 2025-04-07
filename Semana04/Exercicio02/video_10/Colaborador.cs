using System;

class Colaborador : Pessoa
{
    //Atributo

    private double salario;

    //Construtor
    public Colaborador(string nome, int idade, double salario)
    {
       this.nome = nome;
       this.idade = idade;
       this.salario = salario;

       mensagemPessoa();
       mensagemColaborador();

    }
    //Metodo
    private void mensagemColaborador()
    {
        Console. WriteLine("Salário: "+salario);
    }
}