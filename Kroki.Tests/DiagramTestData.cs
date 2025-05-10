using System.IO.Compression;

namespace Kroki.Tests;

public class DiagramTestData : TheoryData<string, FileFormat, string, CompressionLevel?>
{
    public DiagramTestData()
    {
        Dictionary<string, (FileFormat[] OutputFormats, string DiagramSource)> diagramTypes = new()
        {
            [DiagramTypes.BlockDiag] =
                (
                    OutputFormats: [FileFormat.Png, FileFormat.Svg, FileFormat.Pdf],
                    DiagramSource: """
                        blockdiag {
                        Kroki -> generates -> "Block diagrams";
                        Kroki -> is -> "very easy!";

                        Kroki [color = "greenyellow"];
                        "Block diagrams" [color = "pink"];
                        "very easy!" [color = "orange"];
                        }
                        """
                ),
            [DiagramTypes.Bpmn] =
                (
                    OutputFormats: [FileFormat.Svg],
                    DiagramSource: """
                        <?xml version="1.0" encoding="UTF-8"?>
                        <bpmn2:definitions xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:bpmn2="http://www.omg.org/spec/BPMN/20100524/MODEL" xmlns:bpmndi="http://www.omg.org/spec/BPMN/20100524/DI" xmlns:dc="http://www.omg.org/spec/DD/20100524/DC" xmlns:di="http://www.omg.org/spec/DD/20100524/DI" xmlns:qa="http://some-company/schema/bpmn/qa" id="_RdgBELNaEeSYkoSLDs6j-w" targetNamespace="http://activiti.org/bpmn">
                          <bpmn2:process id="Process_1">
                            <bpmn2:task id="Task_1" name="Examine Situation" qa:suitable="0.7">
                              <bpmn2:outgoing>SequenceFlow_1</bpmn2:outgoing>
                              <bpmn2:extensionElements>
                                <qa:analysisDetails lastChecked="2015-01-20" nextCheck="2015-07-15">
                                  <qa:comment author="Klaus">
                                    Our operators always have a hard time to figure out, what they need to do here.
                                  </qa:comment>
                                  <qa:comment author="Walter">
                                    I believe this can be split up in a number of activities and partly automated.
                                  </qa:comment>
                                </qa:analysisDetails>
                              </bpmn2:extensionElements>
                            </bpmn2:task>
                            <bpmn2:sequenceFlow id="SequenceFlow_1" name="" sourceRef="Task_1" targetRef="ExclusiveGateway_1"/>
                            <bpmn2:exclusiveGateway id="ExclusiveGateway_1" name="Things OK?">
                              <bpmn2:incoming>SequenceFlow_1</bpmn2:incoming>
                              <bpmn2:outgoing>SequenceFlow_2</bpmn2:outgoing>
                              <bpmn2:outgoing>SequenceFlow_5</bpmn2:outgoing>
                            </bpmn2:exclusiveGateway>
                            <bpmn2:sequenceFlow id="SequenceFlow_2" name="" sourceRef="ExclusiveGateway_1" targetRef="EndEvent_1"/>
                            <bpmn2:sequenceFlow id="SequenceFlow_5" name="" sourceRef="ExclusiveGateway_1" targetRef="EndEvent_2"/>
                            <bpmn2:endEvent id="EndEvent_1" name="Notification Sent">
                              <bpmn2:incoming>SequenceFlow_2</bpmn2:incoming>
                              <bpmn2:messageEventDefinition id="MessageEventDefinition_1"/>
                            </bpmn2:endEvent>
                            <bpmn2:endEvent id="EndEvent_2" name="Error Propagated">
                              <bpmn2:incoming>SequenceFlow_5</bpmn2:incoming>
                              <bpmn2:errorEventDefinition id="ErrorEventDefinition_1"/>
                            </bpmn2:endEvent>
                          </bpmn2:process>
                          <bpmndi:BPMNDiagram id="BPMNDiagram_1">
                            <bpmndi:BPMNPlane id="BPMNPlane_1" bpmnElement="Process_1">
                              <bpmndi:BPMNShape id="_BPMNShape_Task_2" bpmnElement="Task_1">
                                <dc:Bounds height="80.0" width="100.0" x="96.0" y="196.0"/>
                              </bpmndi:BPMNShape>
                              <bpmndi:BPMNShape id="_BPMNShape_EndEvent_2" bpmnElement="EndEvent_1">
                                <dc:Bounds height="36.0" width="36.0" x="396.0" y="300.0"/>
                                <bpmndi:BPMNLabel>
                                  <dc:Bounds height="0.0" width="0.0" x="414.0" y="341.0"/>
                                </bpmndi:BPMNLabel>
                              </bpmndi:BPMNShape>
                              <bpmndi:BPMNShape id="_BPMNShape_ExclusiveGateway_2" bpmnElement="ExclusiveGateway_1" isMarkerVisible="true">
                                <dc:Bounds height="50.0" width="50.0" x="276.0" y="210.0"/>
                                <bpmndi:BPMNLabel>
                                  <dc:Bounds height="21.0" width="74.0" x="333.0" y="226.0"/>
                                </bpmndi:BPMNLabel>
                              </bpmndi:BPMNShape>
                              <bpmndi:BPMNEdge id="BPMNEdge_SequenceFlow_1" bpmnElement="SequenceFlow_1" sourceElement="_BPMNShape_Task_2" targetElement="_BPMNShape_ExclusiveGateway_2">
                                <di:waypoint xsi:type="dc:Point" x="196.0" y="236.0"/>
                                <di:waypoint xsi:type="dc:Point" x="276.0" y="235.0"/>
                                <bpmndi:BPMNLabel>
                                  <dc:Bounds height="6.0" width="6.0" x="214.0" y="236.0"/>
                                </bpmndi:BPMNLabel>
                              </bpmndi:BPMNEdge>
                              <bpmndi:BPMNEdge id="BPMNEdge_SequenceFlow_2" bpmnElement="SequenceFlow_2" sourceElement="_BPMNShape_ExclusiveGateway_2" targetElement="_BPMNShape_EndEvent_2">
                                <di:waypoint xsi:type="dc:Point" x="301.0" y="260.0"/>
                                <di:waypoint xsi:type="dc:Point" x="301.0" y="318.0"/>
                                <di:waypoint xsi:type="dc:Point" x="396.0" y="318.0"/>
                                <bpmndi:BPMNLabel>
                                  <dc:Bounds height="6.0" width="6.0" x="298.0" y="301.0"/>
                                </bpmndi:BPMNLabel>
                              </bpmndi:BPMNEdge>
                              <bpmndi:BPMNShape id="_BPMNShape_EndEvent_3" bpmnElement="EndEvent_2">
                                <dc:Bounds height="36.0" width="36.0" x="396.0" y="132.0"/>
                                <bpmndi:BPMNLabel>
                                  <dc:Bounds height="0.0" width="0.0" x="414.0" y="173.0"/>
                                </bpmndi:BPMNLabel>
                              </bpmndi:BPMNShape>
                              <bpmndi:BPMNEdge id="BPMNEdge_SequenceFlow_5" bpmnElement="SequenceFlow_5" sourceElement="_BPMNShape_ExclusiveGateway_2" targetElement="_BPMNShape_EndEvent_3">
                                <di:waypoint xsi:type="dc:Point" x="301.0" y="210.0"/>
                                <di:waypoint xsi:type="dc:Point" x="301.0" y="150.0"/>
                                <di:waypoint xsi:type="dc:Point" x="396.0" y="150.0"/>
                                <bpmndi:BPMNLabel>
                                  <dc:Bounds height="6.0" width="6.0" x="333.0" y="150.0"/>
                                </bpmndi:BPMNLabel>
                              </bpmndi:BPMNEdge>
                            </bpmndi:BPMNPlane>
                          </bpmndi:BPMNDiagram>
                        </bpmn2:definitions>
                        """
                ),
            [DiagramTypes.Bytefield] =
                (
                    OutputFormats: [FileFormat.Svg],
                    DiagramSource: """
                        (defattrs :bg-green {:fill "#a0ffa0"})
                        (defattrs :bg-yellow {:fill "#ffffa0"})
                        (defattrs :bg-pink {:fill "#ffb0a0"})
                        (defattrs :bg-cyan {:fill "#a0fafa"})
                        (defattrs :bg-purple {:fill "#e4b5f7"})

                        (defn draw-group-label-header
                          [span label]
                          (draw-box (text label [:math {:font-size 12}]) {:span span :borders #{} :height 14}))

                        (defn draw-remotedb-header
                          [kind args]
                          (draw-column-headers)
                          (draw-group-label-header 5 "start")
                          (draw-group-label-header 5 "TxID")
                          (draw-group-label-header 3 "type")
                          (draw-group-label-header 2 "args")
                          (draw-group-label-header 1 "tags")
                          (next-row 18)

                          (draw-box 0x11 :bg-green)
                          (draw-box 0x872349ae [{:span 4} :bg-green])
                          (draw-box 0x11 :bg-yellow)
                          (draw-box (text "TxID" :math) [{:span 4} :bg-yellow])
                          (draw-box 0x10 :bg-pink)
                          (draw-box (hex-text kind 4 :bold) [{:span 2} :bg-pink])
                          (draw-box 0x0f :bg-cyan)
                          (draw-box (hex-text args 2 :bold) :bg-cyan)
                          (draw-box 0x14 :bg-purple)

                          (draw-box (text "0000000c" :hex [[:plain {:font-weight "light" :font-size 16}] " (12)"]) [{:span 4} :bg-purple])
                          (draw-box (hex-text 6 2 :bold) [:box-first :bg-purple])
                          (doseq [val [6 6 3 6 6 6 6 3]]
                            (draw-box (hex-text val 2 :bold) [:box-related :bg-purple]))
                          (doseq [val [0 0]]
                            (draw-box val [:box-related :bg-purple]))
                          (draw-box 0 [:box-last :bg-purple]))

                        (draw-remotedb-header 0x4702 9)

                        (draw-box 0x11)
                        (draw-box 0x2104 {:span 4})
                        (draw-box 0x11)
                        (draw-box 0 {:span 4})
                        (draw-box 0x11)
                        (draw-box (text "length" [:math] [:sub 1]) {:span 4})
                        (draw-box 0x14)

                        (draw-box (text "length" [:math] [:sub 1]) {:span 4})
                        (draw-gap "Cue and loop point bytes")

                        (draw-box nil :box-below)
                        (draw-box 0x11)
                        (draw-box 0x36 {:span 4})
                        (draw-box 0x11)
                        (draw-box (text "num" [:math] [:sub "hot"]) {:span 4})
                        (draw-box 0x11)
                        (draw-box (text "num" [:math] [:sub "cue"]) {:span 4})

                        (draw-box 0x11)
                        (draw-box (text "length" [:math] [:sub 2]) {:span 4})
                        (draw-box 0x14)
                        (draw-box (text "length" [:math] [:sub 2]) {:span 4})
                        (draw-gap "Unknown bytes" {:min-label-columns 6})
                        (draw-bottom)
                        
                        """
                ),
            [DiagramTypes.SeqDiag] =
                (
                    OutputFormats: [FileFormat.Png, FileFormat.Svg, FileFormat.Pdf],
                    DiagramSource: """
                        seqdiag {
                          browser  -> webserver [label = "GET /seqdiag/svg/base64"];
                          webserver  -> processor [label = "Convert text to image"];
                          webserver <-- processor;
                          browser <-- webserver;
                        }
                        """
                ),
            [DiagramTypes.ActDiag] =
                (
                    OutputFormats: [FileFormat.Png, FileFormat.Svg, FileFormat.Pdf],
                    DiagramSource: """
                        actdiag {
                          write -> convert -> image

                          lane user {
                            label = "User"
                            write [label = "Writing text"];
                            image [label = "Get diagram image"];
                          }
                          lane Kroki {
                            convert [label = "Convert text to image"];
                          }
                        }
                        """
                ),
            [DiagramTypes.NwDiag] =
                (
                    OutputFormats: [FileFormat.Png, FileFormat.Svg, FileFormat.Pdf],
                    DiagramSource: """
                        nwdiag {
                          network dmz {
                            address = "210.x.x.x/24"

                            web01 [address = "210.x.x.1"];
                            web02 [address = "210.x.x.2"];
                          }
                          network internal {
                            address = "172.x.x.x/24";

                            web01 [address = "172.x.x.1"];
                            web02 [address = "172.x.x.2"];
                            db01;
                            db02;
                          }
                        }
                        """
                ),
            [DiagramTypes.PacketDiag] =
                (
                    OutputFormats: [FileFormat.Png, FileFormat.Svg, FileFormat.Pdf],
                    DiagramSource: """
                        packetdiag {
                          colwidth = 32;
                          node_height = 72;

                          0-15: Source Port;
                          16-31: Destination Port;
                          32-63: Sequence Number;
                          64-95: Acknowledgment Number;
                          96-99: Data Offset;
                          100-103: Reserved;
                          104: CWR [rotate = 270];
                          105: ECE [rotate = 270];
                          106: URG [rotate = 270];
                          107: ACK [rotate = 270];
                          108: PSH [rotate = 270];
                          109: RST [rotate = 270];
                          110: SYN [rotate = 270];
                          111: FIN [rotate = 270];
                          112-127: Window;
                          128-143: Checksum;
                          144-159: Urgent Pointer;
                          160-191: (Options and Padding);
                          192-223: data [colheight = 3];
                        }
                        """
                ),
            [DiagramTypes.RackDiag] =
                (
                    OutputFormats: [FileFormat.Png, FileFormat.Svg, FileFormat.Pdf],
                    DiagramSource: """
                        rackdiag {
                          16U;
                          1: UPS [2U];
                          3: DB Server;
                          4: Web Server;
                          5: Web Server;
                          6: Web Server;
                          7: Load Balancer;
                          8: L3 Switch;
                        }
                        """
                ),
            [DiagramTypes.C4PlantUml] =
                (
                    OutputFormats: [FileFormat.Png, FileFormat.Svg, FileFormat.Pdf, FileFormat.Txt, FileFormat.Base64],
                    DiagramSource: """
                        !include <C4/C4_Context>

                        title System Context diagram for Internet Banking System

                        Person(customer, "Banking Customer", "A customer of the bank, with personal bank accounts.")
                        System(banking_system, "Internet Banking System", "Allows customers to check their accounts.")

                        System_Ext(mail_system, "E-mail system", "The internal Microsoft Exchange e-mail system.")
                        System_Ext(mainframe, "Mainframe Banking System", "Stores all of the core banking information.")

                        Rel(customer, banking_system, "Uses")
                        Rel_Back(customer, mail_system, "Sends e-mails to")
                        Rel_Neighbor(banking_system, mail_system, "Sends e-mails", "SMTP")
                        Rel(banking_system, mainframe, "Uses")
                        """
                ),
            [DiagramTypes.D2] =
                (
                    OutputFormats: [FileFormat.Svg],
                    DiagramSource: """
                        D2 Parser: {
                          shape: class

                          # Default visibility is + so no need to specify.
                          +reader: io.RuneReader
                          readerPos: d2ast.Position

                          # Private field.
                          -lookahead: "[]rune"

                          # Protected field.
                          # We have to escape the # to prevent the line from being parsed as a comment.
                          \#lookaheadPos: d2ast.Position

                          +peek(): (r rune, eof bool)
                          rewind()
                          commit()

                          \#peekn(n int): (s string, eof bool)
                        }

                        "github.com/terrastruct/d2parser.git" -> D2 Parser
                        """
                ),
            [DiagramTypes.Dbml] =
                (
                    OutputFormats: [FileFormat.Svg],
                    DiagramSource: """
                        Table users {
                          id integer
                          username varchar
                          role varchar
                          created_at timestamp
                        }

                        Table posts {
                          id integer [primary key]
                          title varchar
                          body text [note: 'Content of the post']
                          user_id integer
                          status post_status
                          created_at timestamp
                        }

                        Enum post_status {
                          draft
                          published
                          private [note: 'visible via URL only']
                        }

                        Ref: posts.user_id > users.id // many-to-one
                        """
                ),
            [DiagramTypes.Ditaa] =
                (
                    OutputFormats: [FileFormat.Png, FileFormat.Svg],
                    DiagramSource: """
                              +--------+
                              |        |
                              |  User  |
                              |        |
                              +--------+
                                  ^
                          request |
                                  v
                          +-------------+
                          |             |
                          |    Kroki    |
                          |             |---+
                          +-------------+   |
                               ^  ^         | inflate
                               |  |         |
                               v  +---------+
                          +-------------+
                          |             |
                          |    Ditaa    |
                          |             |----+
                          +-------------+    |
                                     ^       | process
                                     |       |
                                     +-------+
                              +--------+
                              |        |
                              |  User  |
                              |        |
                              +--------+
                                  ^
                          request |
                                  v
                          +-------------+
                          |             |
                          |    Kroki    |
                          |             |---+
                          +-------------+   |
                               ^  ^         | inflate
                               |  |         |
                               v  +---------+
                          +-------------+
                          |             |
                          |    Ditaa    |
                          |             |----+
                          +-------------+    |
                                     ^       | process
                                     |       |
                                     +-------+

                        """
                ),
            [DiagramTypes.Erd] =
                (
                    OutputFormats: [FileFormat.Png, FileFormat.Svg,/* FileFormat.Jpeg,*/ FileFormat.Pdf],
                    DiagramSource: """
                        [Person]
                        *name
                        height
                        weight
                        +birth_location_id

                        [Location]
                        *id
                        city
                        state
                        country

                        Person *--1 Location
                        """
                ),
            [DiagramTypes.Excalidraw] =
                (
                    OutputFormats: [FileFormat.Svg],
                    DiagramSource: """
                        {
                          "type": "excalidraw",
                          "version": 2,
                          "source": "https://excalidraw.com",

                          "elements": [
                            {
                              "id": "pologsyG-tAraPgiN9xP9b",
                              "type": "rectangle",
                              "x": 928,
                              "y": 319,
                              "width": 134,
                              "height": 90
                            }
                          ],

                          "appState": {
                            "gridSize": 20,
                            "viewBackgroundColor": "#ffffff"
                          },

                          "files": {
                            "3cebd7720911620a3938ce77243696149da03861": {
                              "mimeType": "image/png",
                              "id": "3cebd7720911620a3938c.77243626149da03861",
                              "dataURL": "data:image/png;base64,iVBORWOKGgoAAAANSUhEUgA=",
                              "created": 1690295874454,
                              "lastRetrieved": 1690295874454
                            }
                          }
                        }
                        """
                ),
            [DiagramTypes.GraphViz] =
                (
                    OutputFormats: [FileFormat.Png, FileFormat.Svg, FileFormat.Jpeg, FileFormat.Pdf],
                    DiagramSource: """
                        digraph D {
                          subgraph cluster_p {
                            label = "Kroki";
                            subgraph cluster_c1 {
                              label = "Server";
                              Filebeat;
                              subgraph cluster_gc_1 {
                                label = "Docker/Server";
                                Java;
                              }
                              subgraph cluster_gc_2 {
                                label = "Docker/Mermaid";
                                "Node.js";
                                "Puppeteer";
                                "Chrome";
                              }
                            }
                            subgraph cluster_c2 {
                              label = "CLI";
                              Golang;
                            }
                          }
                        }
                        """
                ),
            [DiagramTypes.Mermaid] =
                (
                    OutputFormats: [FileFormat.Png, FileFormat.Svg],
                    DiagramSource: """
                        graph TD
                          A[ Anyone ] -->|Can help | B( Go to github.com/yuzutech/kroki )
                          B --> C{ How to contribute? }
                          C --> D[ Reporting bugs ]
                          C --> E[ Sharing ideas ]
                          C --> F[ Advocating ]

                        """
                ),
            [DiagramTypes.Nomnoml] =
                (
                    OutputFormats: [FileFormat.Svg],
                    DiagramSource: """
                        [Pirate|eyeCount: Int|raid();pillage()|
                          [beard]--[parrot]
                          [beard]-:>[foul mouth]
                        ]

                        [<abstract>Marauder]<:--[Pirate]
                        [Pirate]- 0..7[mischief]
                        [jollyness]->[Pirate]
                        [jollyness]->[rum]
                        [jollyness]->[singing]
                        [Pirate]-> *[rum|tastiness: Int|swig()]
                        [Pirate]->[singing]
                        [singing]<->[rum]
                        """
                ),
            [DiagramTypes.Pikchr] =
                (
                    OutputFormats: [FileFormat.Svg],
                    DiagramSource: """
                        $r = 0.2in
                        linerad = 0.75*$r
                        linewid = 0.25

                        # Start and end blocks
                        #
                        box "element" bold fit
                        line down 50% from last box.sw
                        dot rad 250% color black
                        X0: last.e + (0.3,0)
                        arrow from last dot to X0
                        move right 3.9in
                        box wid 5% ht 25% fill black
                        X9: last.w - (0.3,0)
                        arrow from X9 to last box.w


                        # The main rule that goes straight through from start to finish
                        #
                        box "object-definition" italic fit at 11/16 way between X0 and X9
                        arrow to X9
                        arrow from X0 to last box.w

                        # The LABEL: rule
                        #
                        arrow right $r from X0 then down 1.25*$r then right $r
                        oval " LABEL " fit
                        arrow 50%
                        oval "\":\"" fit
                        arrow 200%
                        box "position" italic fit
                        arrow
                        line right until even with X9 - ($r,0) \
                          then up until even with X9 then to X9
                        arrow from last oval.e right $r*0.5 then up $r*0.8 right $r*0.8
                        line up $r*0.45 right $r*0.45 then right

                        # The VARIABLE = rule
                        #
                        arrow right $r from X0 then down 2.5*$r then right $r
                        oval " VARIABLE " fit
                        arrow 70%
                        box "assignment-operator" italic fit
                        arrow 70%
                        box "expr" italic fit
                        line right until even with X9 - ($r,0) \
                          then up until even with X9 then to X9

                        # The PRINT rule
                        #
                        arrow right $r from X0 then down 3.75*$r then right $r
                        oval "\"print\"" fit
                        arrow
                        box "print-args" italic fit
                        line right until even with X9 - ($r,0) \
                          then up until even with X9 then to X9
                        """
                ),
            [DiagramTypes.PlantUml] =
                (
                    OutputFormats: [FileFormat.Png, FileFormat.Svg, FileFormat.Pdf, FileFormat.Txt, FileFormat.Base64],
                    DiagramSource: """
                        skinparam ranksep 20
                        skinparam dpi 125
                        skinparam packageTitleAlignment left

                        rectangle "Main" {
                          (main.view)
                          (singleton)
                        }
                        rectangle "Base" {
                          (base.component)
                          (component)
                          (model)
                        }
                        rectangle "<b>main.ts</b>" as main_ts

                        (component) ..> (base.component)
                        main_ts ==> (main.view)
                        (main.view) --> (component)
                        (main.view) ...> (singleton)
                        (singleton) ---> (model)
                        """
                ),
            [DiagramTypes.Structurizr] =
                (
                    OutputFormats: [FileFormat.Png, FileFormat.Svg, FileFormat.Pdf, FileFormat.Txt, FileFormat.Base64],
                    DiagramSource: """
                         workspace {
                            model { 
                                user = person "User" 
                                softwareSystem = softwareSystem "Software System" { 
                                    webapp = container "Web Application" { 
                                        user -> this "Uses!!!" 
                                    } 
                                    database = container "Database" { 
                                        webapp -> this "Reads from and writes to" 
                                    } 
                                } 
                            } 
                            views { 
                                systemContext softwareSystem { 
                                    include * 
                                    autolayout lr 
                                } 
                                container softwareSystem { 
                                    include * 
                                    autolayout lr 
                                } 
                                theme default 
                            } 
                        }
                        """
                ),
            [DiagramTypes.Svgbob] =
                (
                    OutputFormats: [FileFormat.Svg],
                    DiagramSource: """
                                        .-,(  ),-.
                         ___  _      .-(          )-.
                        [___]|=| -->(                )      __________
                        /::/ |_|     '-(          ).-' --->[_...__... ]
                                        '-.( ).-'
                                                \      ____   __
                                                 '--->|    | |==|
                                                      |____| |  |
                                                      /::::/ |__|
                        """
                ),
            [DiagramTypes.Symbolator] =
                (
                    OutputFormats: [FileFormat.Svg],
                    DiagramSource: """
                        module demo_device #(
                            //# {{}}
                            parameter SIZE = 8,
                            parameter RESET_ACTIVE_LEVEL = 1
                        ) (
                            //# {{clocks|Clocking}}
                            input wire clock,
                            //# {{control|Control signals}}
                            input wire reset,
                            input wire enable,
                            //# {{data|Data ports}}
                            input wire [SIZE-1:0] data_in,
                            output wire [SIZE-1:0] data_out
                        );
                          // ...
                        endmodule
                        """
                ),
            [DiagramTypes.TikZ] =
                (
                    OutputFormats: [FileFormat.Png, FileFormat.Svg, FileFormat.Jpeg, FileFormat.Pdf],
                    DiagramSource: """
                        \documentclass{article}
                        \usepackage{tikz}
                        \usepackage{tikz-3dplot}
                        \usetikzlibrary{math}
                        \usepackage[active,tightpage]{preview}
                        \PreviewEnvironment{tikzpicture}
                        \setlength\PreviewBorder{0.125pt}
                        %
                        % File name: directional-angles.tex
                        % Description: 
                        % The directional angles of a vector are geometrically represented.
                        % 
                        % Date of creation: July, 25th, 2021.
                        % Date of last modification: October, 9th, 2022.
                        % Author: Efra�n Soto Apolinar.
                        % https://www.aprendematematicas.org.mx/author/efrain-soto-apolinar/instructing-courses/
                        % Source: page 11 of the 
                        % Glosario Ilustrado de Matematicas Escolares.
                        % https://tinyurl.com/5udm2ufy
                        %
                        % Terms of use:
                        % According to TikZ.net
                        % https://creativecommons.org/licenses/by-nc-sa/4.0/
                        % Your commitment to the terms of use is greatly appreciated.
                        %
                        \begin{document}
                          \tdplotsetmaincoords{80}{120}
                          %
                          \begin{tikzpicture}[tdplot_main_coords,scale=0.75] 
                            % Indicate the components of the vector in rectangular coordinates
                            \pgfmathsetmacro{\ux}{4}
                            \pgfmathsetmacro{\uy}{4}
                            \pgfmathsetmacro{\uz}{3}
                            % Length of each axis
                            \pgfmathsetmacro{\ejex}{\ux+0.5}
                            \pgfmathsetmacro{\ejey}{\uy+0.5}
                            \pgfmathsetmacro{\ejez}{\uz+0.5}
                            \pgfmathsetmacro{\umag}{sqrt(\ux*\ux+\uy*\uy+\uz*\uz)} % Magnitude of vector $\vec{u}$
                            % Compute the angle $\theta$
                            \pgfmathsetmacro{\angthetax}{pi*atan(\uy/\ux)/180}
                            \pgfmathsetmacro{\angthetay}{pi*atan(\ux/\uz)/180}
                            \pgfmathsetmacro{\angthetaz}{pi*atan(\uz/\uy)/180}
                            % Compute the angle $\phi$
                            \pgfmathsetmacro{\angphix}{pi*acos(\ux/\umag)/180}
                            \pgfmathsetmacro{\angphiy}{pi*acos(\uy/\umag)/180}
                            \pgfmathsetmacro{\angphiz}{pi*acos(\uz/\umag)/180}
                            % Compute rho sin(phi) to simplify computations
                            \pgfmathsetmacro{\costz}{cos(\angthetax r)}
                            \pgfmathsetmacro{\sintz}{sin(\angthetax r)}
                            \pgfmathsetmacro{\costy}{cos(\angthetay r)}
                            \pgfmathsetmacro{\sinty}{sin(\angthetay r)}
                            \pgfmathsetmacro{\costx}{cos(\angthetaz r)}
                            \pgfmathsetmacro{\sintx}{sin(\angthetaz r)}
                            % Coordinate axis
                            \draw[thick,->] (0,0,0) -- (\ejex,0,0) node[below left] {$x$};
                            \draw[thick,->] (0,0,0) -- (0,\ejey,0) node[right] {$y$};
                            \draw[thick,->] (0,0,0) -- (0,0,\ejez) node[above] {$z$};
                            % Projections of the components in the axis
                            \draw[gray,very thin,opacity=0.5] (0,0,0) -- (\ux,0,0) -- (\ux,\uy,0) -- (0,\uy,0) -- (0,0,0);	% face on the plane z = 0
                            \draw[gray,very thin,opacity=0.5] (0,0,\uz) -- (\ux,0,\uz) -- (\ux,\uy,\uz) -- (0,\uy,\uz) -- (0,0,\uz);	% face on the plane z = \uz
                            \draw[gray,very thin,opacity=0.5] (0,0,0) -- (0,0,\uz) -- (\ux,0,\uz) -- (\ux,0,0) -- (0,0,0);	% face on the plane y = 0
                            \draw[gray,very thin,opacity=0.5] (0,\uy,0) -- (0,\uy,\uz) -- (\ux,\uy,\uz) -- (\ux,\uy,0) -- (0,\uy,0);	% face on the plane y = \uy
                            \draw[gray,very thin,opacity=0.5] (0,0,0) -- (0,\uy,0) -- (0,\uy,\uz) -- (0,0,\uz) -- (0,0,0); % face on the plane x = 0
                            \draw[gray,very thin,opacity=0.5] (\ux,0,0) -- (\ux,\uy,0) -- (\ux,\uy,\uz) -- (\ux,0,\uz) -- (\ux,0,0); % face on the plane x = \ux
                            % Arc indicating the angle $\alpha$
                            % (angle formed by the vector $\vec{v}$ and the $x$ axis)
                            \draw[red,thick] plot[domain=0:\angphix,smooth,variable=\t] ({cos(\t r)},{sin(\t r)*\costx},{sin(\t r)*\sintx});
                            % Arc indicating the angle $\beta$
                            % (angle formed by the vector $\vec{v}$ and the $y$ axis)
                            \draw[red,thick] plot[domain=0:\angphiy,smooth,variable=\t] ({sin(\t r)*\sinty},{cos(\t r)},{sin(\t r)*\costy});
                            % Arc indicating the angle $\gamma$
                            % (angle formed by the vector $\vec{v}$ and the $z$ axis)
                            \draw[red,thick] plot[domain=0:\angphiz,smooth,variable=\t] ({sin(\t r)*\costz},{sin(\t r)*\sintz},{cos(\t r)});
                            % Vector $\vec{u}$
                            \draw[blue,thick,->] (0,0,0) -- (\ux,\uy,\uz) node [below right] {$\vec{u}$};
                            % Nodes indicating the direction angles
                            \pgfmathsetmacro{\xa}{1.85*cos(0.5*\angphix r)}
                            \pgfmathsetmacro{\ya}{1.85*sin(0.5*\angphix r)*\costx}
                            \pgfmathsetmacro{\za}{1.85*sin(0.5*\angphiz r)*\sintx}
                            \node[red] at (\xa,\ya,\za) {\footnotesize$\alpha$};
                            %
                            \pgfmathsetmacro{\xb}{1.5*sin(0.5*\angphiy r)*\sinty}
                            \pgfmathsetmacro{\yb}{1.5*cos(0.5*\angphiy r)}
                            \pgfmathsetmacro{\zb}{1.5*sin(0.5*\angphiy r)*\costy}
                            \node[red] at (\xb,\yb,\zb) {\footnotesize$\beta$};
                            %
                            \pgfmathsetmacro{\xc}{1.5*sin(0.5*\angphiz r)*\costz}
                            \pgfmathsetmacro{\yc}{1.5*sin(0.5*\angphiz r)*\sintz}
                            \pgfmathsetmacro{\zc}{1.5*cos(0.5*\angphiz r)}
                            \node[red] at (\xc,\yc,\zc) {\footnotesize$\gamma$};
                            %
                          \end{tikzpicture}
                          %
                        \end{document}
                        """
                ),
            //[DiagramTypes.Umlet] =
            //    (
            //        OutputFormats: [FileFormat.Png, FileFormat.Svg, FileFormat.Jpeg],
            //        DiagramSource: """
            //            <umlet_diagram>
            //            <element>
            //            <type>com.umlet.element.base.Relation</type>
            //            <coordinates>
            //            <x>390</x>
            //            <y>160</y>
            //            <w>90</w>
            //            <h>120</h>
            //            </coordinates>
            //            <panel_attributes>lt=-</panel_attributes>
            //            <additional_attributes>70;100;20;20</additional_attributes>
            //            </element>
            //            <element>
            //            <type>com.umlet.element.base.Relation</type>
            //            <coordinates>
            //            <x>390</x>
            //            <y>240</y>
            //            <w>90</w>
            //            <h>80</h>
            //            </coordinates>
            //            <panel_attributes>lt=-</panel_attributes>
            //            <additional_attributes>70;20;20;60</additional_attributes>
            //            </element>
            //            <element>
            //            <type>com.umlet.element.custom.ThreeWayRelation</type>
            //            <coordinates>
            //            <x>460</x>
            //            <y>250</y>
            //            <w>30</w>
            //            <h>20</h>
            //            </coordinates>
            //            <panel_attributes/>
            //            <additional_attributes>transparentSelection=false</additional_attributes>
            //            </element>
            //            <element>
            //            <type>com.umlet.element.base.Relation</type>
            //            <coordinates>
            //            <x>470</x>
            //            <y>240</y>
            //            <w>90</w>
            //            <h>40</h>
            //            </coordinates>
            //            <panel_attributes>lt=-</panel_attributes>
            //            <additional_attributes>70;20;20;20</additional_attributes>
            //            </element>
            //            <element>
            //            <type>com.umlet.element.base.Relation</type>
            //            <coordinates>
            //            <x>360</x>
            //            <y>160</y>
            //            <w>40</w>
            //            <h>160</h>
            //            </coordinates>
            //            <panel_attributes>lt=<- r1=to</panel_attributes>
            //            <additional_attributes>20;140;20;20</additional_attributes>
            //            </element>
            //            <element>
            //            <type>com.umlet.element.base.Class</type>
            //            <coordinates>
            //            <x>310</x>
            //            <y>300</y>
            //            <w>100</w>
            //            <h>30</h>
            //            </coordinates>
            //            <panel_attributes>Airport</panel_attributes>
            //            <additional_attributes>transparentSelection=false</additional_attributes>
            //            </element>
            //            <element>
            //            <type>com.umlet.element.base.Relation</type>
            //            <coordinates>
            //            <x>320</x>
            //            <y>160</y>
            //            <w>40</w>
            //            <h>160</h>
            //            </coordinates>
            //            <panel_attributes>lt=<- r1=from</panel_attributes>
            //            <additional_attributes>20;140;20;20</additional_attributes>
            //            </element>
            //            <element>
            //            <type>com.umlet.element.base.Class</type>
            //            <coordinates>
            //            <x>0</x>
            //            <y>300</y>
            //            <w>100</w>
            //            <h>30</h>
            //            </coordinates>
            //            <panel_attributes>MilesAccount</panel_attributes>
            //            <additional_attributes>transparentSelection=false</additional_attributes>
            //            </element>
            //            <element>
            //            <type>com.umlet.element.base.Relation</type>
            //            <coordinates>
            //            <x>400</x>
            //            <y>150</y>
            //            <w>180</w>
            //            <h>40</h>
            //            </coordinates>
            //            <panel_attributes>lt=- m1=1 r2=fh m2=*</panel_attributes>
            //            <additional_attributes>20;20;160;20</additional_attributes>
            //            </element>
            //            <element>
            //            <type>com.umlet.element.base.Relation</type>
            //            <coordinates>
            //            <x>80</x>
            //            <y>140</y>
            //            <w>260</w>
            //            <h>40</h>
            //            </coordinates>
            //            <panel_attributes>lt=- r1=passagengers m1=* r2=flights m2=*</panel_attributes>
            //            <additional_attributes>20;20;240;20</additional_attributes>
            //            </element>
            //            <element>
            //            <type>com.umlet.element.base.Class</type>
            //            <coordinates>
            //            <x>0</x>
            //            <y>150</y>
            //            <w>100</w>
            //            <h>30</h>
            //            </coordinates>
            //            <panel_attributes>Passenger</panel_attributes>
            //            <additional_attributes>transparentSelection=false</additional_attributes>
            //            </element>
            //            <element>
            //            <type>com.umlet.element.base.Relation</type>
            //            <coordinates>
            //            <x>220</x>
            //            <y>20</y>
            //            <w>57</w>
            //            <h>160</h>
            //            </coordinates>
            //            <panel_attributes>lt=. r1=booking</panel_attributes>
            //            <additional_attributes>28;20;28;140</additional_attributes>
            //            </element>
            //            <element>
            //            <type>com.umlet.element.base.Relation</type>
            //            <coordinates>
            //            <x>350</x>
            //            <y>60</y>
            //            <w>184</w>
            //            <h>114</h>
            //            </coordinates>
            //            <panel_attributes>lt=- <connectingFlights m1=*</panel_attributes>
            //            <additional_attributes>20;84;20;34;100;34;100;74;70;94</additional_attributes>
            //            </element>
            //            <element>
            //            <type>com.umlet.element.base.Class</type>
            //            <coordinates>
            //            <x>560</x>
            //            <y>150</y>
            //            <w>110</w>
            //            <h>30</h>
            //            </coordinates>
            //            <panel_attributes>FlightHandling</panel_attributes>
            //            <additional_attributes>transparentSelection=false</additional_attributes>
            //            </element>
            //            <element>
            //            <type>com.umlet.element.base.Class</type>
            //            <coordinates>
            //            <x>540</x>
            //            <y>240</y>
            //            <w>100</w>
            //            <h>30</h>
            //            </coordinates>
            //            <panel_attributes>Airline</panel_attributes>
            //            <additional_attributes>transparentSelection=false</additional_attributes>
            //            </element>
            //            <element>
            //            <type>com.umlet.element.base.Class</type>
            //            <coordinates>
            //            <x>320</x>
            //            <y>150</y>
            //            <w>100</w>
            //            <h>30</h>
            //            </coordinates>
            //            <panel_attributes>Flight</panel_attributes>
            //            <additional_attributes>transparentSelection=false</additional_attributes>
            //            </element>
            //            <element>
            //            <type>com.umlet.element.base.Class</type>
            //            <coordinates>
            //            <x>200</x>
            //            <y>10</y>
            //            <w>100</w>
            //            <h>30</h>
            //            </coordinates>
            //            <panel_attributes>Booking</panel_attributes>
            //            <additional_attributes>transparentSelection=false</additional_attributes>
            //            </element>
            //            <element>
            //            <type>com.umlet.element.base.Relation</type>
            //            <coordinates>
            //            <x>30</x>
            //            <y>160</y>
            //            <w>40</w>
            //            <h>160</h>
            //            </coordinates>
            //            <panel_attributes>lt=<- m1=0..1 r1=mk</panel_attributes>
            //            <additional_attributes>20;140;20;20</additional_attributes>
            //            </element>
            //            </umlet_diagram>
            //            """
            //    ),
            [DiagramTypes.Vega] =
                (
                    OutputFormats: [FileFormat.Png, FileFormat.Svg, FileFormat.Pdf],
                    DiagramSource: """
                        {
                          "$schema": "https://vega.github.io/schema/vega/v5.json",
                          "width": 400,
                          "height": 200,
                          "padding": 5,

                          "data": [
                            {
                              "name": "table",
                              "values": [
                                {"category": "A", "amount": 28},
                                {"category": "B", "amount": 55},
                                {"category": "C", "amount": 43},
                                {"category": "D", "amount": 91},
                                {"category": "E", "amount": 81},
                                {"category": "F", "amount": 53},
                                {"category": "G", "amount": 19},
                                {"category": "H", "amount": 87}
                              ]
                            }
                          ],

                          "signals": [
                            {
                              "name": "tooltip",
                              "value": {},
                              "on": [
                                {"events": "rect:mouseover", "update": "datum"},
                                {"events": "rect:mouseout",  "update": "{}"}
                              ]
                            }
                          ],

                          "scales": [
                            {
                              "name": "xscale",
                              "type": "band",
                              "domain": {"data": "table", "field": "category"},
                              "range": "width",
                              "padding": 0.05,
                              "round": true
                            },
                            {
                              "name": "yscale",
                              "domain": {"data": "table", "field": "amount"},
                              "nice": true,
                              "range": "height"
                            }
                          ],

                          "axes": [
                            { "orient": "bottom", "scale": "xscale" },
                            { "orient": "left", "scale": "yscale" }
                          ],

                          "marks": [
                            {
                              "type": "rect",
                              "from": {"data":"table"},
                              "encode": {
                                "enter": {
                                  "x": {"scale": "xscale", "field": "category"},
                                  "width": {"scale": "xscale", "band": 1},
                                  "y": {"scale": "yscale", "field": "amount"},
                                  "y2": {"scale": "yscale", "value": 0}
                                },
                                "update": {
                                  "fill": {"value": "steelblue"}
                                },
                                "hover": {
                                  "fill": {"value": "red"}
                                }
                              }
                            },
                            {
                              "type": "text",
                              "encode": {
                                "enter": {
                                  "align": {"value": "center"},
                                  "baseline": {"value": "bottom"},
                                  "fill": {"value": "#333"}
                                },
                                "update": {
                                  "x": {"scale": "xscale", "signal": "tooltip.category", "band": 0.5},
                                  "y": {"scale": "yscale", "signal": "tooltip.amount", "offset": -2},
                                  "text": {"signal": "tooltip.amount"},
                                  "fillOpacity": [
                                    {"test": "datum === tooltip", "value": 0},
                                    {"value": 1}
                                  ]
                                }
                              }
                            }
                          ]
                        }
                        
                        """
                ),
            [DiagramTypes.VegaLite] =
                (
                    OutputFormats: [FileFormat.Png, FileFormat.Svg, FileFormat.Pdf],
                    DiagramSource: """
                        {
                          "$schema": "https://vega.github.io/schema/vega-lite/v4.json",
                          "description": "Horizontally concatenated charts that show different types of discretizing scales.",
                          "data": {
                            "values": [
                              {"a": "A", "b": 28},
                              {"a": "B", "b": 55},
                              {"a": "C", "b": 43},
                              {"a": "D", "b": 91},
                              {"a": "E", "b": 81},
                              {"a": "F", "b": 53},
                              {"a": "G", "b": 19},
                              {"a": "H", "b": 87},
                              {"a": "I", "b": 52}
                            ]
                          },
                          "hconcat": [
                            {
                              "mark": "circle",
                              "encoding": {
                                "y": {
                                  "field": "b",
                                  "type": "nominal",
                                  "sort": null,
                                  "axis": {
                                    "ticks": false,
                                    "domain": false,
                                    "title": null
                                  }
                                },
                                "size": {
                                  "field": "b",
                                  "type": "quantitative",
                                  "scale": {
                                    "type": "quantize"
                                  }
                                },
                                "color": {
                                  "field": "b",
                                  "type": "quantitative",
                                  "scale": {
                                    "type": "quantize",
                                    "zero": true
                                  },
                                  "legend": {
                                    "title": "Quantize"
                                  }
                                }
                              }
                            },
                            {
                              "mark": "circle",
                              "encoding": {
                                "y": {
                                  "field": "b",
                                  "type": "nominal",
                                  "sort": null,
                                  "axis": {
                                    "ticks": false,
                                    "domain": false,
                                    "title": null
                                  }
                                },
                                "size": {
                                  "field": "b",
                                  "type": "quantitative",
                                  "scale": {
                                    "type": "quantile",
                                    "range": [80, 160, 240, 320, 400]
                                  }
                                },
                                "color": {
                                  "field": "b",
                                  "type": "quantitative",
                                  "scale": {
                                    "type": "quantile",
                                    "scheme": "magma"
                                  },
                                  "legend": {
                                    "format": "d",
                                    "title": "Quantile"
                                  }
                                }
                              }
                            },
                            {
                              "mark": "circle",
                              "encoding": {
                                "y": {
                                  "field": "b",
                                  "type": "nominal",
                                  "sort": null,
                                  "axis": {
                                    "ticks": false,
                                    "domain": false,
                                    "title": null
                                  }
                                },
                                "size": {
                                  "field": "b",
                                  "type": "quantitative",
                                  "scale": {
                                    "type": "threshold",
                                    "domain": [30, 70],
                                    "range": [80, 200, 320]
                                  }
                                },
                                "color": {
                                  "field": "b",
                                  "type": "quantitative",
                                  "scale": {
                                    "type": "threshold",
                                    "domain": [30, 70],
                                    "scheme": "viridis"
                                  },
                                  "legend": {
                                    "title": "Threshold"
                                  }
                                }
                              }
                            }
                          ],
                          "resolve": {
                            "scale": {
                              "color": "independent",
                              "size": "independent"
                            }
                          }
                        }
                        
                        """
                ),
            [DiagramTypes.WaveDrom] =
                (
                    OutputFormats: [FileFormat.Svg],
                    DiagramSource: """
                        { signal: [
                          { name: "clk",         wave: "p.....|..." },
                          { name: "Data",        wave: "x.345x|=.x", data: ["head", "body", "tail", "data"] },
                          { name: "Request",     wave: "0.1..0|1.0" },
                          {},
                          { name: "Acknowledge", wave: "1.....|01." }
                        ]}
                        """
                ),
            [DiagramTypes.WireViz] =
                (
                    OutputFormats: [FileFormat.Png, FileFormat.Svg],
                    DiagramSource: """
                        connectors:
                          X1:
                            type: D-Sub
                            subtype: female
                            pinlabels: [DCD, RX, TX, DTR, GND, DSR, RTS, CTS, RI]
                          X2:
                            type: Molex KK 254
                            subtype: female
                            pinlabels: [GND, RX, TX]

                        cables:
                          W1:
                            gauge: 0.25 mm2
                            length: 0.2
                            color_code: DIN
                            wirecount: 3
                            shield: true

                        connections:
                          -
                            - X1: [5,2,3]
                            - W1: [1,2,3]
                            - X2: [1,3,2]
                          -
                            - X1: 5
                            - W1: s
                        """
                ),
        };

        foreach (var v in diagramTypes)
        {
            var diagramType = v.Key;
            var (outputFormats, diagramSource) = v.Value;
            // https://github.com/yuzutech/kroki/issues/1896
            diagramSource = diagramSource.ReplaceLineEndings("\n");
            foreach (var outputFormat in outputFormats)
            {
                Add(diagramType, outputFormat, diagramSource, null);
                Add(diagramType, outputFormat, diagramSource, CompressionLevel.Optimal);
                Add(diagramType, outputFormat, diagramSource, CompressionLevel.Fastest);
                // CompressionLevel.NoCompression causes unnecessary RequestUriTooLong
                Add(diagramType, outputFormat, diagramSource, CompressionLevel.SmallestSize);
            }
        }
    }
}
