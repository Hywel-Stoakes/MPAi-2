from Tkinter import *
from tkSnack import *
import tkSnack
import ttk #unsure of purpose currently
from LoudnessMeter import *
import tkFileDialog

import os
import SoundProcessing
import thread

SIZERATIO = 1.6180339887499 #GoldenRatio

DEFAULTHEIGHT = 580 #Height of the MainFrame

XSHIFT = 75
YSHIFT = 55

XOFFSET =100
YOFFSET=500

SCALEDOWN = 3
class VowelPlot:

    def __init__(self, parent, path, root, id, formApp, vowel, width, height):
        print width, height
        self.width = width
        self.height = height

        self.root = root
        self.formApp = formApp
        self.parent = parent
        self.path = path
        self.id = id
        self.vowel = vowel


        #plot Setup:
        self.setupPlot()


        self.prevX = 0
        self.prevY = 0



        # sound Setup:
        self.initialiseSounds()
        self.Recording = False

        self.drawTarget(vowel)

        self.setUpButtonsFirstTime()


    def setupPlot(self):
        #Plot
        self.formantPlotFrame = self.parent
        self.formantPlotCanvas = Canvas(self.formantPlotFrame, height=self.width, width=self.height, bg='white')
        #self.formantPlotCanvas.grid(row=0 ,column=0, sticky=N+S+E+W)
        self.formantPlotCanvas.pack(fill='both', expand=1)
        #Creates the loudnessMeter on the formant plot canvas.
        self.loudnessMeter = LoudnessMeter(self.formantPlotCanvas,YSHIFT)

        boxWidth= 150
        font = ('Arial','15')

        x1 = (self.height/2) - (boxWidth)
        y1 = 2
        x2 = (self.height/2)
        y2 = 32
        self.recordingBox = self.formantPlotCanvas.create_rectangle(x1,y1,x2,y2, tag='recording', fill='red', outline='black')
        self.recordingBoxText = self.formantPlotCanvas.create_text((x1+x2)/2,(y1+y2)/2, tag='recording', text='Recording.',font=font, fill='black')
        self.formantPlotCanvas.itemconfig('recording', state='hidden')

        x1 = (self.height/2)
        y1 = 2
        x2 = (self.height/2) + boxWidth
        y2 = 32
        self.recordingBox = self.formantPlotCanvas.create_rectangle(x1,y1,x2,y2, tag='Loudness', outline='black')
        self.recordingBoxText = self.formantPlotCanvas.create_text((x1+x2)/2,(y1+y2)/2, tag='toLoud', text='Too Loud.',font=font, fill='black')
        self.recordingBoxText = self.formantPlotCanvas.create_text((x1+x2)/2,(y1+y2)/2, tag='toQuiet', text='Too Quiet.',font=font, fill='black')

        self.formantPlotCanvas.itemconfig('Loudness', state='hidden')
        self.formantPlotCanvas.itemconfig('toLoud', state='hidden')
        self.formantPlotCanvas.itemconfig('toQuiet', state='hidden')

        self.formantPlotCanvas.create_text(self.height/2, self.height-70,tag='helptext', text= "Click on the target to begin.\nAfter 250 Plots the round will finish.")
        self.formantPlotCanvas.create_text(self.height/2, 10, tag='helptext', text="Choose you Vowel to practice.")

    def setUpButtonsFirstTime(self):
        print "First Time setting up buttons."
        font = ('Arial','20')
        vowel = ['a','e','i','o','u']

        y = (self.height/2 - self.yIdeal*2)/3
        height = y
        width = height*SIZERATIO
        gapWidth = width/3
        cenButtonX = (self.height/2)-(width/2)

        x = [cenButtonX - gapWidth*2 - width*2, cenButtonX - gapWidth - width, cenButtonX, cenButtonX + width + gapWidth, cenButtonX + width*2 + gapWidth*2]
        for i in range(0,5):


            buttonFrame = Frame(self.parent, width = (int)(width)*2, height = (int)(height)*2)
            button1 = Button(buttonFrame, text = vowel[i], font=font ,command = lambda vow = vowel[i]: self.changeVowel(vow))

            button1.configure( activebackground = "#33B5E5", relief = 'groove')
            buttonFrame.pack()
            button1.pack()
            button1_window = self.formantPlotCanvas.create_window((int)(x[i]), (int)(y), anchor=NW, window=buttonFrame, tag='firstButtons')

            self.formantPlotCanvas.itemconfig('firstButtons', state = 'normal')

    def resizeRequest():
        pass

    def changeVowel(self, vowel):
        self.formApp.loadVowelPlot(self.id, vowel)


    """
    setUpScore Sets the current score to be 0, creates the score text.
    """
    def setUpScore(self):
        font = ('Arial','18')
        self.formantPlotCanvas.delete('score')
        self.textID = self.formantPlotCanvas.create_text(self.height/2, self.height-60,font=font, tag='score', text=" ---- %")
        self.score = 0
        self.rawScore = 0
        self.scoreCounter = 0

    def updateScore(self, score):
        self.scoreCounter += 1
        self.rawScore += score
        self.score = (int)((float)(self.rawScore)/(float)(self.scoreCounter))
        scoreText = (str)(self.score)+ " %"
        self.formantPlotCanvas.itemconfig(self.textID, text=scoreText)

    def distanceToScore(self, distance):
        if distance < self.xIdeal*0.3:
            score = 100
        elif distance < self.xIdeal*2:
            score = ((self.xIdeal*2) - distance)/(self.xIdeal*2) * 117.65
        else:
            return 0

        self.updateScore((int)(score))

    def displayFinalScore(self):
        self.formantPlotCanvas.itemconfig(self.textID, text = "Final Score: " + (str)(self.score) + " %" )



    def drawTarget(self, letter):
        id = self.id

        data = self.goldStandardMonophthongs(id)
        for f1mean, f1sd, f2mean, f2sd, vowel in data:

            if vowel == letter:
                vowel = letter
                font = ('Arial','22')
                self.f1sd = f1sd
                self.f2sd = f2sd

                self.xShift = ( ((float)(self.height) )/2) - f2mean
                self.yShift = ( ((float)(self.height) )/2) - f1mean

                self.xIdeal = ( ((float)(self.height)/6))
                self.yIdeal = ( ((float)(self.height)/6))


                self.x = f2mean + self.xShift
                self.y = f1mean + self.yShift
                colour = ['#ADD8E6', '#ff4c4c', '#ffff66']
                activeColour = ['#DFFFFF','#ff7f7f','#ffff99']
                i = 0
                for scale in [2,1,0.3]:



                    x1 = self.x + f2sd*scale*(self.xIdeal/f2sd)
                    y1 = self.y + f1sd*scale*(self.yIdeal/f1sd)
                    x2 = self.x - f2sd*scale*(self.xIdeal/f2sd)
                    y2 = self.y - f1sd*scale*(self.yIdeal/f1sd)
                    self.formantPlotCanvas.create_oval(x1,y1,x2,y2, outline='black', tag='vowelOval', fill=colour[i], activefill=activeColour[i])
                    i+=1
                self.formantPlotCanvas.create_text(self.height/2, self.height/2,  fill='#00007f', font = font, tag = 'vowelOval', text=vowel)
                self.formantPlotCanvas.tag_bind('vowelOval',"<Button-1>", lambda event, : self.toggleRecord(event))

    def toggleRecord(self, event):
        if self.Recording:
            self.stop()
        else:
            self.record()

    def goldStandardMonophthongs(self, id):
        path = self.path
        if id == 0:
            data = self.appendData(path,'data\maori\monDataMale.txt')
        elif id == 1:
            data = self.appendData(path,'data\maori\monDataMaleYoung.txt')
        elif id == 2:
            data = self.appendData(path,'data\maori\monDataFemale.txt')
        elif id == 3:
            data = self.appendData(path,'data\maori\monDataFemaleYoung.txt')
        return data

    def appendData(self, pat, str):
        MonophthongDataPath = os.path.join(pat, str)
        MonophthongFile = open(MonophthongDataPath,'r')
        MonophthongData = []
        #Code from ywan478 2010 SoftEng206 Project
        #Load in the monophthong data for males
        for monophthongDataLine in MonophthongFile:
            monophthongDataLine = monophthongDataLine.split()
            #F1 mean and standard deviation
            monophthongDataLine[0]= (float)(monophthongDataLine[0])
            monophthongDataLine[1]= (float)(monophthongDataLine[1])
            #F2 mean and standard deviation
            monophthongDataLine[2]= (float)(monophthongDataLine[2])
            monophthongDataLine[3]= (float)(monophthongDataLine[3])
            MonophthongData.append(monophthongDataLine)
            #End code from ywan478
        return MonophthongData

#***********************************************************************************************************
# Sound

    '''
    Creates the Snack Sound objects used in the formant plot.
    '''
    def initialiseSounds(self):
        tkSnack.initializeSnack(self.root)
        self.recordedAudio = Sound()
        self.soundCopy = Sound()
        self.loadedAudio = Sound()


    #Used for Testing
    def plotFormants2(self, sound):
        #probabilityOfVoicing = SoundProcessing.getProbabilityOfVoicing(sound,False)

        if 1.0 == 1.0:
            #formant = SoundProcessing.getFormants(sound,self.id,False)
            id= self.id
            data = self.goldStandardMonophthongs(id)
            for f1mean, f1sd, f2mean, f2sd, vowel in data:
                if vowel == self.vowel:
                    m1 = f1mean
                    sd1 = f1sd
                    m2 = f2mean
                    sd2 = f2sd
                    for y in [m1-2*sd1,m1-sd1,m1-0.3*sd1, m1,m1+0.3*sd1, m1+sd1, m1+2*sd1,10000]:
                        print y
                        for x in [m2-2*sd2,m2-sd2,m2-0.3*sd2, m2,m2+0.3*sd2, m2+sd2, m2+2*sd2,10000]:
                            print x
                            if 1 != None:
                                radius = 3
                                color = 'black'

                                print x," , ",y
                                xx = self.x + (x + self.xShift-self.x)*self.xIdeal/self.f2sd
                                yy = self.y + (y + self.yShift-self.y)*self.yIdeal/self.f1sd

                                if(abs(x-self.x) > self.height ):
                                    print "OFF X"

                                if(abs(y-self.y) > self.height ):
                                    print "OFF Y"

                                self.formantPlotCanvas.create_oval(xx-radius,yy-radius,xx+radius,yy+radius, fill=color, tags="userformants")
            self.stop()

    """
    Plot Fomrants takes a sound file and plots the last formant in the file.
    """
    def plotFormants(self, sound):
        self.formantPlotCanvas.delete('arrow')
        #Gets the probablity of sound being a voice for the last formant in the sound file. (false means last formant, true means all formants)
        #probabilityOfVoicing = SoundProcessing.getProbabilityOfVoicing(sound,False)

        if True:#probabilityOfVoicing == 1.0:
            formant = SoundProcessing.getFormants(sound,self.id,False)

            #Only plot the latest formants of the sound if there's a good chance that it is the user speaking instead of background noise.
            if formant != None:
                radius = 3
                color = 'black'

                y = formant[0]
                x = formant[1]

                x = self.x + (x + self.xShift-self.x)*self.xIdeal/self.f2sd
                y = self.y + (y + self.yShift-self.y)*self.yIdeal/self.f1sd


                if ((self.prevX-x)**2 + (self.prevY-y)**2)**0.5 < 30:

                    self.formantPlotCanvas.create_oval(x-radius,y-radius,x+radius,y+radius, fill=color, tags="userformants")
                    distance = (((x-self.x)**2+(y-self.y)**2)**0.5)
                    self.plotCount += 1
                    if self.plotCount > 250:
                        print "PlotCount at 250, STOPPING RECORD."
                        self.stop()
                        self.root.after(100 , self.displayFinalScore)
                    self.distanceToScore(distance)

                    if(abs(x-self.x) > self.height ):
                        y1 = y
                        y2 = y+3
                        y3 = y-3
                        if(x < 0):
                            x1 = 8   # |>
                            x2 = 1

                        else:
                            x1 = self.height-8
                            x2 = self.height-1

                        self.formantPlotCanvas.create_line(x2,y1, x1,y2, fill='black', tag='arrow')
                        self.formantPlotCanvas.create_line(x1,y2, x1,y3, fill='black', tag='arrow')
                        self.formantPlotCanvas.create_line(x1,y3, x2,y1, fill='black', tag='arrow')

                    if(abs(y-self.y) > self.height ):
                        print "OFF Y"

                self.prevX = x
                self.prevY = y

    """
    record is called whent eh record button is pressed it starts recording the users sounds
    and makes the formant plot react accordingly.
    """
    def record(self):
        self.recordedAudio = Sound()
        self.setUpScore()
        self.clear()


        self.plotCount = 0
        self.notStopped = True
        self.formantPlotCanvas.itemconfig('helptext', state='hidden')
        self.formantPlotCanvas.itemconfig('firstButtons', state='hidden')
        self.formantPlotCanvas.itemconfig('recording', state='normal')
        self.formantPlotCanvas.itemconfig('Loudness', state='hidden')

        self.recordedAudio.record()
        self.Recording = True
        self.count2 = 0
        thread.start_new_thread(self.multiThreadUpdateCanvas, ("Thread-1", self.notStopped))

    def multiThreadUpdateCanvas(self, threadName, notStopped):
        try:
            while self.notStopped:
                self.count2+=1
                self.soundCopy.copy(self.recordedAudio)
                SoundProcessing.crop(self.soundCopy)
                self.plotFormants(self.soundCopy)
                if self.count2 % 10 == 0:
                    self.updateLoudnessMeter(self.soundCopy)

        except Exception:
            import traceback
            print traceback.format_exc()



    def stop(self):
        self.notStopped = False
        self.formantPlotCanvas.itemconfig('recording', state='hidden')
        self.formantPlotCanvas.itemconfig('toLoud', state='hidden')
        self.formantPlotCanvas.itemconfig('toQuiet', state='hidden')
        self.formantPlotCanvas.itemconfig('Loudness', state='hidden')
        self.formantPlotCanvas.itemconfig('firstButtons', state='normal')




        self.recordedAudio.stop()
        self.Recording = False
        self.root.after(100 ,self.loudnessMeter.clearMeter)
        self.root.after(100 ,self.displayFinalScore)


    def clear(self):
        self.formantPlotCanvas.delete('userformants')

    def updateLoudnessMeter(self, sound):
        try:
            self.loudnessMeter.updateMeter(sound)

        except IndexError:
            print "No sound available to get loudness yet"
