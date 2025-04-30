namespace Kroki;

public static class DiagramTypes
{
    public const string
        BlockDiagram = "blockdiag",
        SequenceDiagram = "seqdiag",
        ActivityDiagram = "actdiag",
        NetworkDiagram = "nwdiag",
        PacketDiagram = "packetdiag",
        RackDiagram = "rackdiag",
        GraphViz = "graphviz",
        Pikchr = "pikchr",
        EntityRelationshipDiagram = "erd",
        Excalidraw = "excalidraw",
        Vega = "vega",
        VegaLite = "vegalite",
        Ditaa = "ditaa",
        Mermaid = "mermaid",
        Nomnoml = "nomnoml",
        PlantUml = "plantuml",
        Bpmn = "bpmn",
        Bytefield = "bytefield",
        Wavedrom = "wavedrom",
        Svgbob = "svgbob",
        C4PlantUml = "c4plantuml",
        Structurizr = "structurizr",
        UMlet = "umlet",
        WireViz = "wireviz",
        Symbolator = "symbolator"
        ;
    public static ReadOnlySpan<string> All => all;
    private static readonly string[] all = 
    [
        BlockDiagram,
        SequenceDiagram,
        ActivityDiagram,
        NetworkDiagram,
        PacketDiagram,
        RackDiagram,
        GraphViz,
        Pikchr,
        EntityRelationshipDiagram,
        Excalidraw,
        Vega,
        VegaLite,
        Ditaa,
        Mermaid,
        Nomnoml,
        PlantUml,
        Bpmn,
        Bytefield,
        Wavedrom,
        Svgbob,
        C4PlantUml,
        Structurizr,
        UMlet,
        WireViz,
        Symbolator,
    ];
}