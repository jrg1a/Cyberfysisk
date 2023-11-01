function y = lavpassfilter(x, dt,RC)
%// Return RC low-pass filter output samples, given input samples,
%// time interval dt, and time constant RC
% Ref Wikipedia: Low Pass Filter
% function lowpass(real[0..n] x, real dt, real RC)
% var real[0..n] y
% var real α := dt / (RC + dt)
% y[0] := α * x[0]
% for i from 1 to n
% y[i] := α * x[i] + (1-α) * y[i-1]
% return y
% Eksempel på bruk:
% y_filter10 = lowpass_r0(y_volt_stoy,1,10);
%
alfa = dt/(RC+dt);
%y(1) = alfa *x(1);
y(1) = x(1);
n = length(x);
for i = 2:n
    y(i) = alfa*x(i) + (1-alfa)*y(i-1);
end
