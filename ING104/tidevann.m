clear, close all;
clc

% tidsvektor
t = 0:1/1440:14;

%tidevannsnivå med to sinuskurver
A1 = (168-21)/2; %døgnfluktuasjon amplitude
A2 = (168-21)/4; % amplitude, 14-dagers fluktuasjon
offset = (168+21)/2;
signal = A1*sin(2*pi*t - pi/2) + A2*sin(2*pi*t/14) + offset; % -pi/2 for å starte med et minimum

% støy
stoy_faktor = 10; %støyfaktor
stoy = stoy_faktor * (rand(1, length(t)) - 0.5); % +/- 10 cm støy
signal_med_stoy = signal + stoy;

% Plott
figure;
plot(t, signal, 'b', t, signal_med_stoy, 'b*');
xlabel('Tid (dager)');
ylabel('Tidevannsnivå (cm)');
title('Simulert Tidevannsnivå med og uten Støy');
legend('Rene signalet', 'Signal med støy');


% bruker lavpassfilter-funksjonen
RC = 0.1; % kan justeres
dt = 1/1440; % tidsintervall på 1 minutt
filtrert_signal = lavpassfilter(signal_med_stoy, dt, RC);

figure;
plot(t, signal, 'b', t, signal_med_stoy, 'b*', t, filtrert_signal, 'kx');
xlabel('Tid (dager)');
ylabel('Tidevannsnivå (cm)');
title('Filtrert Tidevannsnivå');
legend('Rent Støy' ,'Signal med støy', 'Filtrert signal');

filename = 'tidevannsdata.csv';

csvwrite(filename, [t' signal_med_stoy']);
