from distutils.core import setup
import py2exe

setup(
    console=['PlotRunner.py', 'VowelRunner.py'],
    options = {'py2exe': {"dll_excludes": ["msvcr90.dll"]}}
)
