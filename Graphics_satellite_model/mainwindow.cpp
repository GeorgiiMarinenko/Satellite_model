#include "mainwindow.h"
#include "ui_mainwindow.h"

using namespace std;

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    QGraphicsScene *scene = new QGraphicsScene(ui->graphicsView);
    StartDraw(scene);
    ReadFile();
}

MainWindow::~MainWindow()
{
    delete ui;
}

void    MainWindow::StartDraw(QGraphicsScene *scene)
{
    QPen pen(Qt::green);
//    QLine F;
    int x0 = 0;
    double y0 = scene->height();
    int x1 = 0;
    double y1 = 0;
//    scene->addLine(0,90,180,90,pen);//x
//    scene->addLine(90,0,90,180,pen);//y
    int i = 0;
    while (i < 1000)
    {
        x1 = i;
        y1 = (cosf(x0) * 360);
        scene->addLine(x0,(int)y0, x1, (int)y1, pen);
//        qDebug() << y1 << "\t" << scene->height();
        x0 = x1;
        y0 = y1;
        i += 3;
    }
    ui->graphicsView->setScene(scene);
}

const QString MainWindow::allFileToString(QFile &aFile)
{
    if (!aFile.open(QFile::ReadOnly | QFile::Text))
    {
        cout << "Error opening file!" << endl;
        return NULL;
    }
    QTextStream in(&aFile);
    return in.readAll();
}

void MainWindow::setDataToVector(const QStringList &aStringList, QVector< QVector <int> > &aVector)
{
    size_t x = aStringList.size() - 1; // Count of line, 8
    size_t y = aStringList.at(0).count("\t") + 1; // Count of digits in line, 6

    for (size_t i = 0; i < x; ++i)
    {
        QVector<int> temp_vector;
        for (size_t j = 0; j < y; ++j)
        {
            temp_vector.push_back(aStringList.at(i).split("\t").at(j).toInt());
        }
        aVector.push_back(temp_vector);
    }
}

void MainWindow::printVector(const QVector< QVector <int> > &aVector)
{
    for (int i = 0; i < aVector.size(); ++i)
    {
        for (int j = 0; j < aVector.at(0).size(); ++j)
        {
            cout << aVector.at(i).at(j) << "\t";
        }
        cout << endl;
    }
}

void    MainWindow::ReadFile()
{
    QFile file("/Users/georgy/Desktop/fileout.txt");
    QStringList strList;
    QTextStream str(&file);

    if((file.exists())&&(file.open(QIODevice::ReadOnly)))
    {
        while(!file.atEnd())
        {
            strList << file.readLine();
        }
    }
    else
    {
        qDebug() << "Error";
        return;
    }
    ui->textBrowser->setText(strList[2]);
}


//QFile fileIn("/Users/georgy/Desktop/fileout.txt");
//    if(fileIn.open(QIODevice::ReadOnly))
//    { //Если первый файл открыт для чтения, а второй для записи успешн
//        QByteArray block = fileIn.read(10000); // Считываем 10 байт в массив block из filein.txt
//        qDebug() << QString(block);
//        fileIn.close(); // Закрываем filein.txt
//    }

void MainWindow::on_pushButton_clicked()
{
    QFile file("/Users/georgy/Desktop/fileout.txt");
    if (!file.open(QIODevice::ReadOnly))
        QMessageBox::information(0, "info", file.errorString());

    QTextStream in(&file);

    ui->textBrowser->setText(in.readAll());
}