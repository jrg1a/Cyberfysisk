clc;
%function f
f = @(x)sin(2*x)+exp(2*x)-2;
% df/dx 
Df = @(x)2*cos(2*x)+2*exp(2*x);

N = 20; %antall iterasjoner / max iterations
x=2.0; % første gjett / first guess (has to be somewhat close)
i = 0; % index

while abs(f(x)) > 0.5*10^(-6)
    i = i+1;
    if i>N
        break;
    end
    %newtons metode
    x = x - f(x)/Df(x);
    fprintf(' i : %i , x = %.10g , d=%.10g' , i , x , abs ( f ( x ) ) ) 
end
