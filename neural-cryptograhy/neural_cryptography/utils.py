import numpy as np


def utf32_encode(message, sentence_len):
    sen = np.zeros((1, sentence_len))
    for i, a in enumerate(message.encode('utf-32')):
        sen[0, i] = a
    return sen


def utf32_decode(message):
    data = message[0].argmax(-1)
    symbols = []
    for i in range(4, len(data), 4):
        symbols.append(bytes([int(data[i - 4]), int(data[i - 3]), int(data[i - 2]), int(data[i - 1])]).decode('utf-32'))
    return ''.join(symbols)
