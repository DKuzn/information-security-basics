from neural_cryptography import data_generator, get_model
from tensorflow.keras.callbacks import ModelCheckpoint


if __name__ == '__main__':
    image_shape = (100, 100, 3)
    sentence_len = 100
    max_word = 256
    gen = data_generator(image_shape, sentence_len, max_word, 64)
    model, encoder, decoder = get_model(image_shape, sentence_len, max_word)
    model.fit(gen, epochs=512, steps_per_epoch=348, callbacks=[
            ModelCheckpoint('best_weights.h5',monitor='loss',
                            verbose=1,
                            save_weights_only=True,
                            save_best_only=True)]
        )
