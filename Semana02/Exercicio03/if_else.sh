#!/bin/bash
# Estrutura If/Elif/Else

echo "Digite um número:"
read num

if [ $num -gt 10 ]; then
  echo "Número maior que 10"
elif [ $num -eq 10 ]; then
  echo "Número é 10"
else
  echo "Número menor que 10"
fi
