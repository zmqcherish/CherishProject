import os
import random
from PIL import Image, ImageFont, ImageDraw

def create_img(pic_size=(1224,1224)):
    h = ['³³⁰', '⁵²⁰', '₃₃₀', '₅₂₀', 'ᴴᵉᵇᵉ', 'ᴴᵉᵇᵉ', 'ᴴᵉᵇᵉ', 'ꓱꓭꓱꓧ', 'ꓱꓭꓱꓧ', '♥', '♥', 'hebe', 'hebe', 'ʰᵉᵇᵉ', 'ʰᵉᵇᵉ']
    font = ImageFont.truetype("segoeuil.ttf", 30)

    im = Image.new("RGBA", pic_size, (175, 2280, 110, 255))
    text = ''
    for i in range(1000):
        if i>20 and i%20 == 0:
            text += '\n'
        text += random.choice(h) + '    '
    dr = ImageDraw.Draw(im)
    dr.text((0, 0), text, font=font, fill="#000000")
    # im.show()
    im.save("t.png")

def create_font(content, font_size = 30):
    font = ImageFont.truetype("msyh.ttf", font_size)
    im = Image.new("RGBA", (1300, 578), (255, 255, 255, 255))
    dr = ImageDraw.Draw(im)
    textsize = dr.textsize(content, font)
    dr.text((50,0), content, font=font, fill="#000000")
    im.save("{}.png".format(content))

def paste_img():
    mask = Image.open('mask.png')
    t = Image.open('t.png')
    t.paste(mask)
    t.save('t3.png', 'PNG')

def change_img():
    mask = Image.open('mask.png')
    t = Image.open('t.png')
    pix_mask = mask.load()
    pix_t = t.load()
    size = t.size
    for i in range(size[0]):
        for j in range(size[1]):
            if pix_mask[i,j][0] == 255:
                pix_t[i,j] = (255,255,255,0)
    t.save('t2.png')

def change_img2():
    mask = Image.open('hebe.png')
    mask_pix = mask.load()
    size = mask.size
    target = Image.open('tt.png')
    if target.size != size:
        bounds = (0, 0, size[0], size[1])
        target = target.crop(bounds)
    target_pix = target.load()

    for i in range(size[0]):
        for j in range(size[1]):
            if mask_pix[i,j][0] == 255:
                target_pix[i,j] = (255,255,255,0)
    target.save('target.png')

# create_font('田馥甄', 400)
change_img2()
# create_img((1300,1300))
# change_img()
# paste_img()

