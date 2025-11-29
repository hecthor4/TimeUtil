const diaSel = document.getElementById("día");
const mesSel = document.getElementById("mes");
const añoSel = document.getElementById("año");
const btn = document.getElementById("crear");
const contenedorResultados = document.getElementById("contenedor-resultados");

//meses
const meses = [
    "enero","febrero","marzo","abril","mayo","junio","julio","agosto","septiembre","octubre","noviembre","diciembre"
];

meses.forEach((m, i) => {
    const op = document.createElement("option");
    op.value = i;
    op.textContent = m;
    mesSel.appendChild(op);
});

//dias
for (let i = 1; i <= 31; i++) {
    let op = document.createElement("option");
    op.value = i;
    op.textContent = i;
    diaSel.appendChild(op);
}

//años
const currentYear = new Date().getFullYear();
for (let i = currentYear; i <= currentYear + 10; i++) {
    let op = document.createElement("option");
    op.value = i;
    op.textContent = i;
    añoSel.appendChild(op);
}


//validar fechas
function esFechaValida(año, mes, dia) {
    const fecha = new Date(año, mes, dia);
    return (
        fecha.getFullYear() == año &&
        fecha.getMonth() == mes &&
        fecha.getDate() == dia
    );
}


//crear recordatorio
btn.onclick = function () {
    const titulo = document.getElementById("titulo").value.trim();
    const mes = parseInt(mesSel.value);
    const dia = parseInt(diaSel.value);
    const año = parseInt(añoSel.value);

    //valida fechas
    if (!esFechaValida(año, mes, dia)) {
        const errorDiv = document.createElement("div");
        errorDiv.classList.add("recordatorio", "error");
        errorDiv.textContent = `Error: La fecha ${dia} de ${meses[mes]} de ${año} no existe.`;
        contenedorResultados.appendChild(errorDiv);
        return;
    }

    //calcular
    const hoy = new Date();
    const fechaObjetivo = new Date(año, mes, dia);

    const diffTime = fechaObjetivo - hoy;
    const diasRestantes = Math.ceil(diffTime / (1000 * 60 * 60 * 24));

    //nuevo bloque
    const recDiv = document.createElement("div");
    recDiv.classList.add("recordatorio");
    recDiv.textContent = `${titulo} / Quedan: ${diasRestantes} días.`;

    contenedorResultados.appendChild(recDiv);
};