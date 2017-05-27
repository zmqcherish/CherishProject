from PIL import Image, ImageFont, ImageDraw


lrc_img = "wyyyy.jpg"



def create_lrc_img(cover, title, lrcs):
    font = ImageFont.truetype("apple.ttf", 32)
    font_color = '#2a2a2a'
    title = '——「{}」'.format(title)
    lrcs = lrcs.split('.')
    num = len(lrcs)
    width = 750
    height = width + 100 + num * 60 + 160
    horiz_offset = 40
    uper_offset = width + 40
    pic_size = (width, height)
    im = Image.new("RGB", pic_size, (255, 255, 255))

    dr = ImageDraw.Draw(im)
    for i in range(num):
        dr.text((horiz_offset, uper_offset + 60 * i), lrcs[i], font=font, fill=font_color)

    title_size = dr.textsize(title, font)
    dr.text((width - 15 - title_size[0], uper_offset + 60 * num + 60), title, font=font, fill=font_color)   #title

    im.paste(Image.open('{}.jpg'.format(cover)).resize((width, width)))
    im.paste(Image.open('wyy.jpg'), (0, uper_offset + 60 * num + 130))
    im.show()
    im.save(lrc_img)

lrc = '原来你是我最想留住的幸运.原来我们和爱情曾经靠得那么近.那为我对抗世界的决定.那陪我淋的雨.一幕幕都是你.一尘不染的真心'
create_lrc_img('1','小幸运', lrc)