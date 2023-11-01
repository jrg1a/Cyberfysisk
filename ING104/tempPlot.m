clear, close all
clc


%tid
dager = 7;
minutter_dag = 24*60;
minutter_tot = minutter_dag * dager;

t_strek = linspace(0, dager, minutter_tot);

max_t = 15; %maks tempratur
min_t = 8; % lavest tempratur
mid_t = (max_t + min_t) / 2; %gjennomsnitt
amp_t = (max_t - min_t) / 2; % amplitude

tempratur = mid_t + amp_t * sin(2*pi * t_strek); % temp data generert

plot( t_strek, tempratur);
xlabel('Dager');
ylabel('Temp');

amp_s = 1.5; % amplitude støy

stoy = rand(1, minutter_tot);
stoy_pluss_minus = stoy - 0.5;
stoy_skalert = stoy_pluss_minus * 2;
%temp_stoy = tempratur + stoy_skalert*amp_s;

% Forenklet metode av det som skjer i koden over
temp_stoy = tempratur+(rand(1, minutter_tot)-0.5)*2*amp_s;



plot(t_strek, temp_stoy);
xlabel('Dager');
ylabel('Temperatur med støy');

okning = 1; % økning per dag! 
okning_total = linspace(0, okning * (dager - 1), minutter_tot);
temp_stoy_med_okning = temp_stoy + okning_total;


plot(t_strek, temp_stoy_med_okning);
xlabel('Dager');
ylabel('Temperattur med støy og økning');

% Beregner og skriver ut gjennomsnittstemperaturen for hver dag
for i = 1:dager
    start_idx = (i-1) * minutter_dag + 1;
    slutt_idx = i * minutter_dag;
    daglig_temp = temp_stoy_med_okning(start_idx:slutt_idx);
    daglig_snitt = mean(daglig_temp);
    fprintf('Gjennomsnittstemperatur for dag %d: %.2f grader\n', i, daglig_snitt);
end


temp_med_okning = tempratur + okning_total;
plot(t_strek, temp_med_okning);
xlabel('Dager');
ylabel('Tempratur med Økning');
for i = 1:dager
    start_idx = (i-1) * minutter_dag + 1;
    slutt_idx = i * minutter_dag;
    daglig_temp = temp_med_okning(start_idx:slutt_idx);
    daglig_snitt = mean(daglig_temp);
    fprintf('Gjennomsnittstemperatur for dag %d: %.2f grader\n', i, daglig_snitt);
end
