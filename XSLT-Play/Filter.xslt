<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>

  <xsl:template match="Employees">
    <table width="50%">
      <tr align="left">
        <th>EmpId</th>
        <th>Name</th>
        <th>Sex</th>
        <th>Phone</th>
      </tr>

      <xsl:for-each select="Employee">
        <xsl:sort select="EmpId" order="descending"/>
        <xsl:if test="EmpId &gt; 2">  <!-- applied in order, if first matches then second can not catch-->
        <tr>
          <td>
            <xsl:value-of select="EmpId"/>
          </td>
          <td>
            <xsl:value-of select="Name"/>
          </td>
          <td>
            <xsl:value-of select="Sex"/>
          </td>
          <td>
            <xsl:value-of select="Phone"/>
          </td>
        </tr>
        </xsl:if>
        <xsl:if test="Sex= 'Female'">
          <tr style="color:red">
            <td>
              <xsl:value-of select="EmpId"/>
            </td>
            <td>
              <xsl:value-of select="Name"/>
            </td>
            <td>
              <xsl:value-of select="Sex"/>
            </td>
            <td>
              <xsl:value-of select="Phone"/>
            </td>
          </tr>
        </xsl:if>

      </xsl:for-each>
    </table>
  </xsl:template>

  
</xsl:stylesheet>
