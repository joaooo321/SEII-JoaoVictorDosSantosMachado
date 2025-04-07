#include "float_vector.h"
#include <stdlib.h>
#include <stdio.h>
#include <stdbool.h>

struct float_vector { int capacity, size; float *data; };

bool _FloatVector_isFull(const FloatVector *vec) { return vec->size == vec->capacity; }

FloatVector *FloatVector_create(int capacity) {
    FloatVector *vec = (FloatVector*) calloc(1, sizeof(FloatVector));
    vec->capacity = capacity;
    vec->data = (float*) calloc(capacity, sizeof(float));
    return vec;
}

void FloatVector_destroy(FloatVector **vec_ref) {
    free((*vec_ref)->data);
    free(*vec_ref);
    *vec_ref = NULL;
}

int FloatVector_size(const FloatVector *vec) { return vec->size; }
int FloatVector_capacity(const FloatVector *vec) { return vec->capacity; }

float FloatVector_at(const FloatVector *vec, int index) {
    if (index < 0 || index >= vec->size) { fprintf(stderr, "Index [%d] out of bounds\n", index); exit(EXIT_FAILURE); }
    return vec->data[index];
}

float FloatVector_get(const FloatVector *vec, int index) { return vec->data[index]; }

void FloatVector_append(FloatVector *vec, float val) {
    if (_FloatVector_isFull(vec)) { fprintf(stderr, "Vector is full\n"); exit(EXIT_FAILURE); }
    vec->data[vec->size++] = val;
}

void FloatVector_set(FloatVector *vec, int index, float val) {
    if (index < 0 || index >= vec->size) { fprintf(stderr, "Index [%d] out of bounds\n", index); exit(EXIT_FAILURE); }
    vec->data[index] = val;
}

void FloatVector_print(const FloatVector *vec) {
    printf("Size: %d\nCapacity: %d\n", vec->size, vec->capacity);
    for (int i = 0; i < vec->size; i++) printf("[%d] = %f\n", i, vec->data[i]);
}
