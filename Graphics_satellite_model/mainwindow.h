#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "ui_mainwindow.h"

#include <QDebug>
#include <QByteArray>
#include <QString>
#include <QVector>
#include <QString>
#include <QStringList>
#include <iostream>

#include <QFile>
#include <QTextStream>
#include <QMessageBox>

QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
    void StartDraw(QGraphicsScene *scene);
    void ReadFile();

    const QString allFileToString(QFile &aFile);
    void setDataToVector(const QStringList &aStringList,QVector< QVector <int> > &aVector);
    void printVector(const QVector< QVector <int> > &aVector);

private slots:
    void on_pushButton_clicked();

private:
    Ui::MainWindow *ui;
};
#endif // MAINWINDOW_H
