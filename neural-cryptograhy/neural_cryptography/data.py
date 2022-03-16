import numpy as np


def rand_img(size):
    return np.random.randint(0, 256, size) / 255.0


def rand_sentence(len, max):
    return np.random.randint(0, max, len)


def onehot(sentece, max):
    onehot = np.zeros((len(sentece), max))
    for i, v in enumerate(sentece):
        onehot[i, v] = 1
    return onehot


def data_generator(image_size, sentence_len, sentence_max_word, batch_size=32):
    while True:
        x_img = np.zeros((batch_size, image_size[0], image_size[1], image_size[2]))
        x_sen = np.zeros((batch_size, sentence_len))
        y_img = np.zeros((batch_size, image_size[0], image_size[1], image_size[2]))
        y_sen = np.zeros((batch_size, sentence_len, sentence_max_word))
        for i in range(batch_size):
            img = rand_img(image_size)
            sentence = rand_sentence(sentence_len, sentence_max_word)
            sentence_onehot = onehot(sentence, sentence_max_word)
            x_img[i] = img
            x_sen[i] = sentence
            y_img[i] = img
            y_sen[i] = sentence_onehot
        yield [x_img, x_sen], [y_img, y_sen]
