from PIL import Image, ImageFont, ImageDraw

lrc_img = "wyyyy.jpg"
font_path = 'apple.ttf'

def create_lrc_img(cover_path, title, lrcs, add_footer=True):

    font = ImageFont.truetype(font_path, 32)

    font_color = '#2a2a2a'

    title = '——「{}」'.format(title)

    num = len(lrcs)

    width = 750
    footer_heght = 80 if add_footer else 0
    height = width + footer_heght + num * 60 + 150  #40+50+40+20
    pic_size = (width, height)

    horiz_offset = 40
    uper_offset = width + 40

    img = Image.new("RGB", pic_size, (255, 255, 255))

    dr = ImageDraw.Draw(img)

    for i in range(num):
        # title_size = dr.textsize(lrcs[i], font)
        dr.text((horiz_offset, uper_offset + 60 * i), lrcs[i], font=font, fill=font_color)

    title_size = dr.textsize(title, font)

    uper_offset += 60 * num + 50
    dr.text((width - 15 - title_size[0], uper_offset), title, font=font, fill=font_color)   #title

    img.paste(Image.open(cover_path).resize((width, width)))

    if footer_heght:
        img.paste(Image.open('wyy.jpg'), (0, uper_offset + 60))

    img.show()

    img.save(lrc_img)

cover = '1.png' #大小至少750，正方形
title = '小幸运'
lrcs = '原来你是我最想留住的幸运.原来我们和爱情曾经靠得那么近.那为我对抗世界的决定.那陪我淋的雨.一幕幕都是你'
lrcs = lrcs.split('.')
create_lrc_img(cover, title , lrcs)