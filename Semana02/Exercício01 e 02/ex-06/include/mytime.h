#ifndef MY_TIME_H
#define MY_TIME_H

#include <stdio.h>
#include <stdlib.h>
#include <sys/time.h>

// Medindo tempo em C (Linux/Mac)
// Para Windows, veja http://professor.ufabc.edu.br/~daniel.martin/ED/tempo.html

typedef struct timeval timer; // Adicionando um novo nome para struct timeval (apenas para facilitar)

// Função que marca o tempo atual ("tic" do relógio)
// Deve ser usada para marcar o início do trecho que queremos medir
timer tic();

// Faz a mesma coisa que a função tic, mas deve ser usada
// para marcar o final do trecho que queremos medir o tempo.
// Apenas uma forma semântica de sabermos que faz o "tac" do relógio
timer tac();

/**
 * Computa o tempo entre um tic-tac (em ms)
 */
float compTime(timer tic, timer tac);

#endif
