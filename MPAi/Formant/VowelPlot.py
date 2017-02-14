from Tkinter import *
from tkSnack import *
import tkSnack
import ttk #unsure of purpose currently
from LoudnessMeter import *
import tkFileDialog

import os
import SoundProcessing
from time import sleep

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
        self.axisButtonClicked = False
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
        self.Waiting = False

        self.drawTarget(vowel)

    def setupPlot(self):
        #Plot
        self.vowelPlotFrame = self.parent
        self.vowelPlotCanvas = Canvas(self.vowelPlotFrame, height=self.width, width=self.height, bg='white')
        self.vowelPlotCanvas.delete('Loudness')
        self.vowelPlotCanvas.delete('toLoud')
        self.vowelPlotCanvas.delete('toQuiet')
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
        self.recordingBoxText = self.vowelPlotCanvas.create_text((x1+x2)/2,(y1+y2)/2, tag='recordingText', text='Recording.',font=font, fill='black')
        self.vowelPlotCanvas.itemconfig('recording', state='hidden')
        self.vowelPlotCanvas.itemconfig('recordingText', state='hidden')


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
        self.vowelPlotCanvas.delete('tophelptext')

        self.vowelPlotCanvas.create_text(self.width/2, self.height-50,tag='helptext', font=self.font, text= "Click on the target to begin.")
        self.vowelPlotCanvas.create_text(self.width/2, self.height-30,tag='helptext', font=self.font, text= "After 250 Plots the round will finish.")
        self.vowelPlotCanvas.create_text(self.width/2, 10, tag='tophelptext', font=self.font, text="Choose a Vowel to practice.")

    def setUpButtonsFirstTime(self):
        self.vowelPlotCanvas.delete("firstButtons")
        font = ('Arial','20')
        vowel = ['a:','e:','i:','o:','u:']


        aButton = Button(self.parent, text = vowel[0], font = font, command = lambda vow=vowel[0]: self.changeVowel(vow))
        aButton.configure( activebackground = "#FA4A4A", relief  = GROOVE)
        aButtonWindow = self.vowelPlotCanvas.create_window(self.width/2 - 160, 50, window = aButton, tags="firstButtons")

        eButton = Button(self.parent, text = vowel[1], font = font, command = lambda vow=vowel[1]: self.changeVowel(vow))
        eButton.configure( activebackground = "#FA4A4A", relief  = GROOVE)
        eButtonWindow = self.vowelPlotCanvas.create_window(self.width/2 - 80, 50, window = eButton, tags="firstButtons")

        iButton = Button(self.parent, text = vowel[2]+" ", font = font, command = lambda vow=vowel[2]: self.changeVowel(vow))
        iButton.configure( activebackground = "#FA4A4A", relief  = GROOVE)
        iButtonWindow = self.vowelPlotCanvas.create_window(self.width/2, 50, window = iButton, tags="firstButtons")

        oButton = Button(self.parent, text = vowel[3], font = font, command = lambda vow=vowel[3]: self.changeVowel(vow))
        oButton.configure( activebackground = "#FA4A4A", relief  = GROOVE)
        oButtonWindow = self.vowelPlotCanvas.create_window(self.width/2 + 80, 50, window = oButton, tags="firstButtons")

        uButton = Button(self.parent, text = vowel[4], font = font, command = lambda vow=vowel[4]: self.changeVowel(vow))
        uButton.configure( activebackground = "#FA4A4A", relief  = GROOVE)
        uButtonWindow = self.vowelPlotCanvas.create_window(self.width/2 + 160, 50, window = uButton, tags="firstButtons")

        analysisButton = Button(self.parent, text="    Analysis    \nand\ngo back",command=self.requestQuit, font = ('Arial','15') )
        analysisButton.configure(activebackground='#FA4A4A', anchor=W, relief = GROOVE)
        analysisButtonWindow = self.vowelPlotCanvas.create_window(4, self.height-4, anchor=SW,tags=('analysisButton', 'firstButtons'),window=analysisButton)

    def requestQuit(self):
        self.formApp.quitApp()

    #handles the Resizing of the application and all its child. currently disabled.
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
        self.vowelPlotCanvas.itemconfig('Loudness', state='hidden')
        self.vowelPlotCanvas.itemconfig('toLoud', state='hidden')
        self.vowelPlotCanvas.itemconfig('toQuiet', state='hidden')

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

                self.vowelPlotCanvas.delete('questionMarkButton')
                self.questionMarkButton = Button(self.parent, text = " Show Axis", command=self.showAxisClicked, font = ('Arial', '13'))
                self.questionMarkButton.configure(activebackground='#FA4A4A', bg = 'white', anchor=W, relief = GROOVE)
                questionMarkButtonWindow = self.vowelPlotCanvas.create_window(self.width - 2, self.height - 2, anchor=SE,tags=('questionMarkButton'),window=self.questionMarkButton)
                self.questionMarkButton.bind("<Enter>", self.showAxisHoovering)
                self.questionMarkButton.bind("<Leave>", self.hideAxisHoovering)

                self.drawAxis()

    def showAxisHoovering(self, *args):
        if not self.axisButtonClicked:
            self.questionMarkButton.config(relief=SUNKEN)
            self.showAxis()

    def hideAxisHoovering(self, *args):
        if not self.axisButtonClicked:
            self.questionMarkButton.config(relief=GROOVE, bg = 'white')
            self.hideAxis()
    def showAxisClicked(self, *args):
        if self.axisButtonClicked:
            self.questionMarkButton.config( bg = 'white')

            self.hideAxis
            self.axisButtonClicked = False
        else:
            self.questionMarkButton.config(relief =SUNKEN, bg = '#FA4A4A')
            self.showAxis
            self.axisButtonClicked = True

    def showAxis(self):
        self.vowelPlotCanvas.itemconfig('axis', state='normal')

    def hideAxis(self):
        self.vowelPlotCanvas.itemconfig('axis', state='hidden')

    def drawAxis(self):
        self.vowelPlotCanvas.delete('axis')
        axisFont = ('Arial','13')

        #Draw y Axis
        xAxis = self.width/2
        yAxis1 = (self.height/2) - self.yIdeal*2
        yAxis2 = (self.height/2) - self.yIdeal*0.3
        yAxis3 = (self.height/2) + self.yIdeal*0.3
        yAxis4 = (self.height/2) + self.yIdeal*2 + 25
        self.vowelPlotCanvas.create_line(xAxis, yAxis1, xAxis, yAxis2, tags='axis', width = 2)
        self.vowelPlotCanvas.create_line(xAxis, yAxis3, xAxis, yAxis4, tags='axis', width = 2)

        for index in range(2,10):
            yCoor = index * ((self.yIdeal*2)/10)
            self.vowelPlotCanvas.create_line( xAxis, self.height/2 + yCoor, xAxis-6, self.height/2 + yCoor, tags = 'axis', width = 2)
            self.vowelPlotCanvas.create_line( xAxis, self.height/2 - yCoor, xAxis-6, self.height/2 - yCoor, tags = 'axis', width = 2)

        self.vowelPlotCanvas.create_text(xAxis+10, yAxis1 - 15, text="Mouth Less Open",  tags='axis',font=axisFont, anchor=CENTER)
        self.vowelPlotCanvas.create_text(xAxis+10, yAxis4 + 10, text="Mouth More Open", tags='axis', font=axisFont, anchor=CENTER)

        #ArrowHead y
        self.vowelPlotCanvas.create_polygon(( self.width/2, yAxis4+3, self.width/2-10, yAxis4-17, self.width/2+10, yAxis4-17), tags='axis' , fill='#000000')

        #Draw x Axis
        yAxis = self.height/2
        xAxis1 = (self.width/2) - self.xIdeal*2 - 25
        xAxis2 = (self.width/2) - self.xIdeal*0.3
        xAxis3 = (self.width/2) + self.xIdeal*0.3
        xAxis4 = (self.width/2) + self.xIdeal*2
        self.vowelPlotCanvas.create_line(xAxis1, yAxis, xAxis2, yAxis, tags='axis', width = 2)
        self.vowelPlotCanvas.create_line(xAxis3, yAxis, xAxis4, yAxis, tags='axis', width = 2)

        for index in range(2,10):
            xCoor = index * ((self.xIdeal*2)/10)
            self.vowelPlotCanvas.create_line(self.width/2 + xCoor, yAxis, self.width/2 + xCoor, yAxis+6,tags = 'axis', width = 2)
            self.vowelPlotCanvas.create_line(self.width/2 - xCoor, yAxis, self.width/2 - xCoor, yAxis+6,tags = 'axis', width = 2)

        self.vowelPlotCanvas.create_text(xAxis4+40, yAxis-20, text="Tongue", tags='axis', font=axisFont, anchor=CENTER)
        self.vowelPlotCanvas.create_text(xAxis4+40, yAxis, text="Less", tags='axis', font=axisFont, anchor=CENTER)
        self.vowelPlotCanvas.create_text(xAxis4+40, yAxis+20, text="Forward", tags='axis', font=axisFont, anchor=CENTER)

        self.vowelPlotCanvas.create_text(xAxis1-40, yAxis-20, text="Tongue", tags='axis', font=axisFont, anchor=CENTER)
        self.vowelPlotCanvas.create_text(xAxis1-40, yAxis, text="More", tags='axis', font=axisFont, anchor=CENTER)
        self.vowelPlotCanvas.create_text(xAxis1-40, yAxis+20, text="Forward", tags='axis', font=axisFont, anchor=CENTER)

        #ArrowHead x
        self.vowelPlotCanvas.create_polygon((xAxis1-3, self.height/2, xAxis1+17, self.height/2-10, xAxis1+17, self.height/2+10), tags='axis', fill='#000000')

        if self.axisButtonClicked:
            self.vowelPlotCanvas.itemconfig('axis', state='normal')
            self.questionMarkButton.config(relief =SUNKEN, bg = '#FA4A4A')

        else:
            self.vowelPlotCanvas.itemconfig('axis', state='hidden')
            self.questionMarkButton.config(relief =GROOVE, bg = 'white')

    def toggleRecord(self, event):
        if self.Recording:
            self.stop()
        else:
            self.record()

    def goldStandardDiphthongs(self, id):
        path = self.path
        if id == 0:
            data = self.appendData(path,'data\maori\longVowelNativeMale.txt')
        elif id == 1:
            data = self.appendData(path,'data\maori\longVowelModernMale.txt')
        elif id == 2:
            data = self.appendData(path,'data\maori\longVowelNativeFemale.txt')
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
                self.Waiting = False
                self.vowelPlotCanvas.itemconfig('questionMarkButton', state = 'hidden')
                self.formApp.preventResizing()
                self.xFormantList = []
                self.yFormantList = []
                self.recordedAudio = Sound()
                self.clear()

                self.plotCount = 0
                self.notStopped = True
                self.vowelPlotCanvas.itemconfig('waitingText', state='hidden')
                #self.vowelPlotCanvas.itemconfig('axis', state='normal')
                self.vowelPlotCanvas.itemconfig('analysisButton', state = 'hidden')
                self.vowelPlotCanvas.itemconfig('firstButtons', state='hidden')
                self.vowelPlotCanvas.itemconfig('recording', state='normal')
                self.vowelPlotCanvas.itemconfig('Loudness', state='hidden')
                self.vowelPlotCanvas.itemconfig('tophelptext', state='hidden')
                self.vowelPlotCanvas.itemconfig('helptext', state='hidden')
                self.vowelPlotCanvas.itemconfig('score', state='hidden')

                self.recordedAudio.record()
                self.count2 = 0

                self.vowelPlotCanvas.itemconfig('recording', state='normal', fill='orange')
                self.vowelPlotCanvas.itemconfig('recordingText', state ='normal', text='Loading...')

                #LOADING AXIS.


                thread.start_new_thread(self.multiThreadUpdateCanvas, ("Thread-1", self.notStopped))
            else:
                print "Not SafeToRecord, please Wait..."
        except Exception:
            self.requestQuit()

    def multiThreadUpdateCanvas(self, threadName, notStopped):
        sleep(1.2)
        self.setUpScore()
        self.isLoading = False
        #self.vowelPlotCanvas.itemconfig('axis', state='hidden')
        self.vowelPlotCanvas.itemconfig('score', state='normal')

        try:
            self.vowelPlotCanvas.itemconfig('recording', fill='red')
            self.vowelPlotCanvas.itemconfig('recordingText', text = 'Recording')
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
        if self.vowelScorer.safeToRecord():

            self.notStopped = False
            self.vowelPlotCanvas.itemconfig('recording', state='hidden')
            self.vowelPlotCanvas.itemconfig('recordingText', state='hidden')
            self.vowelPlotCanvas.itemconfig('waitingText', state='normal')
            self.vowelPlotCanvas.itemconfig('toLoud', state='hidden')
            self.vowelPlotCanvas.itemconfig('toQuiet', state='hidden')
            self.vowelPlotCanvas.itemconfig('Loudness', state='hidden')
            self.vowelPlotCanvas.itemconfig('analysisButton', state = 'normal')
            self.vowelPlotCanvas.itemconfig('firstButtons', state='normal')
            self.vowelPlotCanvas.itemconfig('tophelptext', state='hidden')
            self.vowelPlotCanvas.itemconfig('helptext', state='hidden')
            self.vowelPlotCanvas.itemconfig('score', state='normal')
            self.vowelPlotCanvas.itemconfig('questionMarkButton', state= 'normal')
            self.recordedAudio.stop()
            self.root.after(100 ,self.loudnessMeter.clearMeter)
            self.Recording = False
            self.Waiting = True
            self.vowelScorer.updateScore(self.vowel, self.rawScore, self.plottedInfo)
            self.rawScore = 0
            self.plotCounter = 0
            self.plottedInfo = [0,0,0,0,0]
            self.root.after(500 ,self.requestFinalScore)
            self.vowelPlotCanvas.itemconfig('toLoud', state='hidden')
            self.vowelPlotCanvas.itemconfig('toQuiet', state='hidden')
            self.vowelPlotCanvas.itemconfig('Loudness', state='hidden')

    def requestFinalScore(self):
        self.displayFinalScore(self.vowelScorer.getLastScore())
        self.vowelPlotCanvas.itemconfig('toLoud', state='hidden')
        self.vowelPlotCanvas.itemconfig('toQuiet', state='hidden')
        self.vowelPlotCanvas.itemconfig('Loudness', state='hidden')

    def clear(self):
        self.vowelPlotCanvas.delete('userformants')
        self.hasPlots = False

    def updateLoudnessMeter(self, sound):
        try:
            self.loudnessMeter.updateMeter(sound)

        except IndexError:
            print "No sound available to get loudness yet"
