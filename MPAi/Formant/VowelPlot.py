from Tkinter import *
from tkSnack import *
import tkSnack
import ttk #unsure of purpose currently
from LoudnessMeter import *
import tkFileDialog

import os
import SoundProcessing
import thread

DEFAULTHEIGHT = 680
DEFAULTWIDTH = 680

XSHIFT = 75
YSHIFT = 55

XOFFSET =100
YOFFSET=500

SCALEDOWN = 3
class VowelPlot:

    def __init__(self, parent, path, root, id, formApp, vowelScorer, vowel, width, height):
        self.vowelScorer = vowelScorer
        self.width = width
        self.height = height
        self.root = root
        self.formApp = formApp
        self.parent = parent
        self.path = path
        self.id = id
        self.vowel = vowel
        self.hasPlots = False

        self.hasScore = False
        self.firstTime = True
        #plot Setup:
        self.setupPlot()

        self.plottedInfo = [0,0,0,0,0]

        self.prevX = 0
        self.prevY = 0

        # sound Setup:
        self.initialiseSounds()
        self.Recording = False

        self.drawTarget(vowel)

    def setupPlot(self):
        #Plot
        self.vowelPlotFrame = self.parent
        self.vowelPlotCanvas = Canvas(self.vowelPlotFrame, height=self.width, width=self.height, bg='white')

        self.vowelPlotCanvas.pack(fill='both', expand=1)

        #Creates the loudnessMeter on the formant plot canvas.
        self.loudnessMeter = LoudnessMeter(self.vowelPlotCanvas,YSHIFT)
        font = ('Arial','14')
        boxWidth= 150
        self.font = font
        x1 = (self.height/2) - (boxWidth)
        y1 = 2
        x2 = (self.height/2)
        y2 = 32
        self.recordingBox = self.vowelPlotCanvas.create_rectangle(x1,y1,x2,y2, tag='recording', fill='red', outline='white')
        self.recordingBoxText = self.vowelPlotCanvas.create_text((x1+x2)/2,(y1+y2)/2, tag='recording', text='Recording.',font=font, fill='black')
        self.vowelPlotCanvas.itemconfig('recording', state='hidden')

        x1 = (self.height/2)
        y1 = 2
        x2 = (self.height/2) + boxWidth
        y2 = 32
        self.recordingBox = self.vowelPlotCanvas.create_rectangle(x1,y1,x2,y2, tag='Loudness', outline='black')
        self.recordingBoxText = self.vowelPlotCanvas.create_text((x1+x2)/2,(y1+y2)/2, tag='toLoud', text='Too Loud.',font=font, fill='black')
        self.recordingBoxText = self.vowelPlotCanvas.create_text((x1+x2)/2,(y1+y2)/2, tag='toQuiet', text='Too Quiet.',font=font, fill='black')

        self.vowelPlotCanvas.itemconfig('Loudness', state='hidden')
        self.vowelPlotCanvas.itemconfig('toLoud', state='hidden')
        self.vowelPlotCanvas.itemconfig('toQuiet', state='hidden')



    def createText(self):
        self.vowelPlotCanvas.delete('helptext')
        self.vowelPlotCanvas.create_text(self.width/2, self.height-60,tag='helptext', font=self.font, text= "Click on the target to begin.")
        self.vowelPlotCanvas.create_text(self.width/2, self.height-40,tag='helptext', font=self.font, text= "After 250 Plots the round will finish.")
        self.vowelPlotCanvas.create_text(self.width/2, 10, tag='helptext', font=self.font, text="Choose a Vowel to practice.")

    def setUpButtonsFirstTime(self):
        self.vowelPlotCanvas.delete("firstButtons")
        font = ('Arial','20')
        vowel = ['a:','e:','i:','o:','u:']


        aButton = Button(self.parent, text = vowel[0], font = font, command = lambda vow=vowel[0]: self.changeVowel(vow))
        aButton.configure( activebackground = "#33B5E5", relief  = GROOVE)
        aButtonWindow = self.vowelPlotCanvas.create_window(self.width/2 - 160, 50, window = aButton, tags="firstButtons")

        eButton = Button(self.parent, text = vowel[1], font = font, command = lambda vow=vowel[1]: self.changeVowel(vow))
        eButton.configure( activebackground = "#33B5E5", relief  = GROOVE)
        eButtonWindow = self.vowelPlotCanvas.create_window(self.width/2 - 80, 50, window = eButton, tags="firstButtons")

        iButton = Button(self.parent, text = vowel[2]+" ", font = font, command = lambda vow=vowel[2]: self.changeVowel(vow))
        iButton.configure( activebackground = "#33B5E5", relief  = GROOVE)
        iButtonWindow = self.vowelPlotCanvas.create_window(self.width/2, 50, window = iButton, tags="firstButtons")

        oButton = Button(self.parent, text = vowel[3], font = font, command = lambda vow=vowel[3]: self.changeVowel(vow))
        oButton.configure( activebackground = "#33B5E5", relief  = GROOVE)
        oButtonWindow = self.vowelPlotCanvas.create_window(self.width/2 + 80, 50, window = oButton, tags="firstButtons")

        uButton = Button(self.parent, text = vowel[4], font = font, command = lambda vow=vowel[4]: self.changeVowel(vow))
        uButton.configure( activebackground = "#33B5E5", relief  = GROOVE)
        uButtonWindow = self.vowelPlotCanvas.create_window(self.width/2 + 160, 50, window = uButton, tags="firstButtons")

        analysisButton = Button(self.parent, text="    Analysis    \nand\ngo back",command=self.requestQuit, font = ('Arial','15') )
        analysisButton.configure(activebackground='green', anchor=W, relief = GROOVE)
        analysisButtonWindow = self.vowelPlotCanvas.create_window(4, self.height-4, anchor=SW,tags=('analysisButton', 'firstButtons'),window=analysisButton)


        # y = (self.height/2 - self.yIdeal*2)/3
        # height = y
        # width = height*1.62
        # gapWidth = width/3
        # cenButtonX = (self.height/2)-(width/2)
        #
        # x = [cenButtonX - gapWidth*2 - width*2, cenButtonX - gapWidth - width, cenButtonX, cenButtonX + width + gapWidth, cenButtonX + width*2 + gapWidth*2]
        # for i in range(0,5):
        #
        #
        #     buttonFrame = Frame(self.parent, width = (int)(width)*2, height = (int)(height)*2)
        #     button = Button(buttonFrame, text = vowel[i], font=font ,command = lambda vow = vowel[i]: self.changeVowel(vow))
        #
        #     button.configure( activebackground = "#33B5E5", relief = 'groove')
        #     buttonFrame.pack()
        #     button.pack()
        #     buttonWindow = self.vowelPlotCanvas.create_window((int)(x[i]), (int)(y), anchor=NW, window=buttonFrame, tag='firstButtons')
        #
        #     self.vowelPlotCanvas.itemconfig('firstButtons', state = 'normal')
    def requestQuit(self):
        self.formApp.quitApp()

    def onResize(self, width, height):

        self.width = width
        self.height = height

        self.drawTarget(self.vowel)
        self.createText()

        self.setUpButtonsFirstTime()
        #rebind configure event being fired from root changes.
        if(self.hasScore):
            self.redrawScore()

        if(self.hasPlots):
            self.replotFormants()

    def changeVowel(self, vowel):
        self.formApp.loadVowelPlot(self.id, vowel,self.width,self.height)


    """
    setUpScore Sets the current score to be 0, creates the score text.
    """
    def setUpScore(self):
        self.hasScore = True
        font = ('Arial','18')
        self.vowelPlotCanvas.delete('score')
        self.textID = self.vowelPlotCanvas.create_text(self.width/2, self.height-60,font=font, tag='score', text=" ---- %")
        self.score = 0
        self.rawScore = 0
        self.scoreCounter = 0

    def redrawScore(self):
        print self.score
        font = ('Arial','18')
        self.vowelPlotCanvas.delete('score')
        if self.score == 0:
            scoreText = ' ---- %'
        else:
            scoreText = (str)(self.score)+ " %"

        self.textID = self.vowelPlotCanvas.create_text(self.width/2, self.height-(60*(self.height/DEFAULTHEIGHT)), tag='score', font=font, text=scoreText)


    def updateScore(self, score):
        self.hasScore = True
        self.scoreCounter += 1
        self.rawScore += score
        self.score = (int)((float)(self.rawScore)/(float)(self.scoreCounter))
        scoreText = (str)(self.score)+ " %"
        self.vowelPlotCanvas.itemconfig(self.textID, text=scoreText)

    def displayFinalScore(self, score):
        scoreText = "Score: "+(str)(score)+ " %"
        self.vowelPlotCanvas.itemconfig(self.textID, text=scoreText)
        self.score = score

    def distanceToScore(self, distance):

        self.plottedInfo[0] += 1

        if distance < self.xIdeal*0.3:
            score = 100
            self.plottedInfo[1] += 1
        elif distance < self.xIdeal*2:
            self.plottedInfo[2] += 1

            score = ((self.xIdeal*2) - distance)/(self.xIdeal*2) * 117.65
        else:
            self.plottedInfo[0] -= 1
            self.plottedInfo[3] += 1
            return 0

        self.updateScore((int)(score))



    def drawTarget(self, letter):
        self.vowelPlotCanvas.delete("vowelOval")
        id = self.id
        font = ('Arial','20')

        data = self.goldStandardDiphthongs(id)
        for f1mean, f1sd, f2mean, f2sd, vowel in data:
            if vowel == letter:
                vowel = letter
                self.f1sd = f1sd
                self.f2sd = f2sd

                self.xShift = ( ((float)(self.width) )/2) - f2mean
                self.yShift = ( ((float)(self.height) )/2) - f1mean

                self.xIdeal = ( ((float)(self.width)/6))
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
                    self.vowelPlotCanvas.create_oval(x1,y1,x2,y2, outline='black', tag='vowelOval', fill=colour[i], activefill=activeColour[i])
                    i+=1
                self.vowelPlotCanvas.create_text(self.width/2, self.height/2,  fill='#00007f', font = font, tag = 'vowelOval', text=vowel)
                self.vowelPlotCanvas.tag_bind('vowelOval',"<Button-1>", lambda event, : self.toggleRecord(event))

    def toggleRecord(self, event):
        if self.Recording:
            self.stop()
        else:
            self.record()

    def goldStandardDiphthongs(self, id):
        path = self.path
        if id == 0:
            data = self.appendData(path,'data\maori\longVowelHeritageMale.txt')
        elif id == 1:
            data = self.appendData(path,'data\maori\longVowelModernMale.txt')
        elif id == 2:
            data = self.appendData(path,'data\maori\longVowelHeritageFemale.txt')
        elif id == 3:
            data = self.appendData(path,'data\maori\longVowelModernFemale.txt')
        return data

    """
    appendData retrieves the data from the longVowelFile for a langType and voiceType.
    This code was edited from code written by ywan478 during his SoftEng206 Project 2010.
    """
    def appendData(self, path, str):
        longVowelDataPath = os.path.join(path, str)
        longVowelFile = open(longVowelDataPath,'r')
        longVowelData = []
        #Load in the longVowel data
        for longVowelDataLine in longVowelFile:
            longVowelDataLine = longVowelDataLine.split()
            #F1 mean and standard deviation
            longVowelDataLine[0]= (float)(longVowelDataLine[0])
            longVowelDataLine[1]= (float)(longVowelDataLine[1])
            #F2 mean and standard deviation
            longVowelDataLine[2]= (float)(longVowelDataLine[2])
            longVowelDataLine[3]= (float)(longVowelDataLine[3])
            longVowelData.append(longVowelDataLine)
        return longVowelData

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


    #TESTING MOCK FUNCTION: Start
    def plotFormants2(self, sound):
        self.hasPlots = True
        #probabilityOfVoicing = SoundProcessing.getProbabilityOfVoicing(sound,False)

        if 1.0 == 1.0:
            #formant = SoundProcessing.getFormants(sound,self.id,False)
            id= self.id
            data = self.goldStandardDiphthongs(id)
            for f1mean, f1sd, f2mean, f2sd, vowel in data:
                if vowel == self.vowel:
                    m1 = f1mean
                    sd1 = f1sd
                    m2 = f2mean
                    sd2 = f2sd
                    count = 0
                    for y in [m1-2*sd1,m1-sd1,m1-0.3*sd1, m1,m1+0.3*sd1, m1+sd1, m1+2*sd1]:
                        for x in [m2-2*sd2,m2-sd2,m2-0.3*sd2, m2,m2+0.3*sd2, m2+sd2, m2+2*sd2]:
                            count+=1


                            radius = 3
                            color = 'black'

                            xx = self.x + (x + self.xShift-self.x)*self.xIdeal/self.f2sd
                            yy = self.y + (y + self.yShift-self.y)*self.yIdeal/self.f1sd

                            self.vowelPlotCanvas.create_oval(xx-radius,yy-radius,xx+radius,yy+radius, fill=color, tags="userformants")
                            self.xFormantList.append(x)
                            self.yFormantList.append(y)

            self.stop()

    #TESTING MOCK FUNCTION: END

    """
    Plot Fomrants takes a sound file and plots the last formant in the file.
    """
    def plotFormants(self, sound):
        self.hasPlots = True

        self.vowelPlotCanvas.delete('arrow')
        #Gets the probablity of sound being a voice for the last formant in the sound file. (false means last formant, true means all formants)
        probabilityOfVoicing = SoundProcessing.getProbabilityOfVoicing(sound,False)

        if True:#probabilityOfVoicing == 1.0:
            formant = SoundProcessing.getFormants(sound,self.id,False)

            #Only plot the latest formants of the sound if there's a good chance that it is the user speaking instead of background noise.
            if formant != None:
                radius = 3
                color = 'black'

                yFormant = formant[0]
                xFormant = formant[1]

                x = self.x + (xFormant + self.xShift-self.x)*self.xIdeal/self.f2sd
                y = self.y + (yFormant + self.yShift-self.y)*self.yIdeal/self.f1sd

                #Remove some background noise.
                if ((self.prevX-x)**2 + (self.prevY-y)**2)**0.5 < 28:

                    self.vowelPlotCanvas.create_oval(x-radius,y-radius,x+radius,y+radius, fill=color, tags="userformants")

                    self.xFormantList.append(xFormant)
                    self.yFormantList.append(yFormant)

                    distance = (((x-self.x)**2+(y-self.y)**2)**0.5)
                    if distance < self.xIdeal*2:
                        self.plotCount += 1

                    if self.plotCount > 250:
                        self.stop()
                        #self.root.after(100 , self.displayFinalScore)

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

                        # self.vowelPlotCanvas.create_line(x2,y1, x1,y2, fill='black', tag='arrow')
                        # self.vowelPlotCanvas.create_line(x1,y2, x1,y3, fill='black', tag='arrow')
                        # self.vowelPlotCanvas.create_line(x1,y3, x2,y1, fill='black', tag='arrow')

                    if(abs(y-self.y) > self.height ):
                        pass

                self.prevX = x
                self.prevY = y

    def replotFormants(self):
        self.vowelPlotCanvas.delete("userformants")
        color = 'black'
        radius = 3
        for index in range(len(self.xFormantList)):
            xFormant = self.xFormantList[index]
            yFormant = self.yFormantList[index]
            x = self.x + (xFormant + self.xShift-self.x)*self.xIdeal/self.f2sd
            y = self.y + (yFormant + self.yShift-self.y)*self.yIdeal/self.f1sd
            self.vowelPlotCanvas.create_oval(x-radius,y-radius,x+radius,y+radius, fill=color, tags="userformants")


    """
    record is called whent eh record button is pressed it starts recording the users sounds
    and makes the formant plot react accordingly.
    """
    def record(self):
        try:
            if self.vowelScorer.safeToRecord():
                self.Recording = True

                self.formApp.preventResizing()
                self.xFormantList = []
                self.yFormantList = []
                self.recordedAudio = Sound()
                self.setUpScore()
                self.clear()

                self.plotCount = 0
                self.notStopped = True
                self.vowelPlotCanvas.itemconfig('analysisButton', state = 'hidden')
                self.vowelPlotCanvas.itemconfig('helptext', state='hidden')
                self.vowelPlotCanvas.itemconfig('firstButtons', state='hidden')
                self.vowelPlotCanvas.itemconfig('recording', state='normal')
                self.vowelPlotCanvas.itemconfig('Loudness', state='hidden')

                self.recordedAudio.record()
                self.count2 = 0
                thread.start_new_thread(self.multiThreadUpdateCanvas, ("Thread-1", self.notStopped))
            else:
                print "Not SafeToRecord, please Wait..."
        except Exception:
            self.requestQuit()

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
            print "ERROR:",traceback.format_exc()



    def stop(self):
        if self.vowelScorer.safeToRecord():

            self.notStopped = False
            self.vowelPlotCanvas.itemconfig('recording', state='hidden')
            self.vowelPlotCanvas.itemconfig('toLoud', state='hidden')
            self.vowelPlotCanvas.itemconfig('toQuiet', state='hidden')
            self.vowelPlotCanvas.itemconfig('Loudness', state='hidden')
            self.vowelPlotCanvas.itemconfig('firstButtons', state='normal')

            self.recordedAudio.stop()
            self.root.after(100 ,self.loudnessMeter.clearMeter)
            #self.root.after(100 ,self.displayFinalScore)
            self.Recording = False
            self.vowelScorer.updateScore(self.vowel, self.rawScore, self.plottedInfo)
            self.rawScore = 0
            self.plotCounter = 0
            self.plottedInfo = [0,0,0,0,0]
            self.vowelPlotCanvas.itemconfig('analysisButton', state='normal')
            #self.root.after(100,self.formApp.allowResizing)

            self.vowelPlotCanvas.itemconfig('Loudness', state='hidden')
            self.vowelPlotCanvas.itemconfig('toLoud', state='hidden')
            self.vowelPlotCanvas.itemconfig('toQuiet', state='hidden')
            self.root.after(500 ,self.requestFinalScore)

    


    def requestFinalScore(self):
        print "Requesting Final Score"
        self.displayFinalScore(self.vowelScorer.getLastScore())

    def clear(self):
        self.vowelPlotCanvas.delete('userformants')
        self.hasPlots = False

    def updateLoudnessMeter(self, sound):
        try:
            self.loudnessMeter.updateMeter(sound)

        except IndexError:
            print "No sound available to get loudness yet"
