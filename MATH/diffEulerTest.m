% Definerer differensialligningen
% For eksempel: dy/dt = t + y
f = @(t, y) t + y;

% Initialbetingelser og parametere
t0 = 0;  % Starttid
y0 = .5;  % Initialverdi for y
h = 0.1; % Steglengde
n = 50;  % Antall steg

% Kjører Eulers metode
[t, y] = eulerMethod(f, t0, y0, h, n);

% Plotter resultatet
plot(t, y);
xlabel('t');
ylabel('y');
title('Løsning av ODE ved hjelp av Eulers metode');
grid on;
