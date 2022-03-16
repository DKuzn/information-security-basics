from tensorflow.keras.layers import Input, Embedding, Flatten, Reshape, Conv2D, Concatenate, TimeDistributed, Dense
from tensorflow.keras.models import Model, Sequential
from tensorflow.keras.metrics import mean_absolute_error, categorical_crossentropy, categorical_accuracy


def get_model(image_shape, sentence_len, max_word):
    input_img = Input(image_shape)
    input_sen = Input((sentence_len,))
    embed_sen = Embedding(max_word, 100)(input_sen)
    flat_emb_sen = Flatten()(embed_sen)
    flat_emb_sen = Reshape((image_shape[0], image_shape[1], 1))(flat_emb_sen)
    trans_input_img = Conv2D(20, 1, activation='relu')(input_img)
    enc_input = Concatenate(axis=-1)([flat_emb_sen, trans_input_img])
    out_img = Conv2D(3, 1, activation='relu', name='image_reconstruction')(enc_input)

    decoder_model = Sequential(name='sentence_reconstruction')
    decoder_model.add(Conv2D(1, 1, input_shape=(100, 100, 3)))
    decoder_model.add(Reshape((sentence_len, 100)))
    decoder_model.add(TimeDistributed(Dense(max_word, activation='softmax')))
    out_sen = decoder_model(out_img)
    
    model = Model(inputs=[input_img, input_sen], outputs=[out_img, out_sen])
    model.compile('adam', loss=[mean_absolute_error, categorical_crossentropy],
                  metrics={'sentence_reconstruction': categorical_accuracy})
    encoder_model = Model(inputs=[input_img, input_sen], outputs=[out_img])
    return model, encoder_model, decoder_model
